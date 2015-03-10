using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mangtas.Sample.Domains;
using Mangtas.Sample.Services;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace Mangtas.Sample.Controllers
{
    public class PersonServiceController: ApiController
    {
        private readonly IPersonBukService _personBukService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public PersonServiceController(
            IUnitOfWorkAsync unitOfWorkAsync,
            IPersonBukService personBukService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _personBukService = personBukService;
        }

        // GET: api/PersonService
        public IQueryable<Person> Get()
        {
            return _personBukService.Queryable();
        }

        // GET: api/PersonService/5
        public SingleResult<Person> Get(string id)
        {
            Guid key = Guid.Parse(id);
            return SingleResult.Create(_personBukService.Queryable().Where(t => t.Id == key));
        }

        // POST: api/PersonService
        public async Task<HttpResponseMessage> Post(Person person)
        {
            
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            person.ObjectState = ObjectState.Added;
            _personBukService.Insert(person);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT: api/PersonService/5
        public async Task<HttpResponseMessage> Put(string id, Person person)
        {
            Guid key = Guid.Parse(id);
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            if (key != person.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            person.ObjectState = ObjectState.Modified;
            _personBukService.Update(person);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                throw;
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE: api/PersonService/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            Guid key = Guid.Parse(id);
            Person person = await _personBukService.FindAsync(key);

            if (person == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            person.ObjectState = ObjectState.Deleted;

            _personBukService.Delete(person);
            await _unitOfWorkAsync.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #region Helper
        private bool PersonExists(Guid key)
        {
            return _personBukService.Query(e => e.Id == key).Select().Any();
        }
        #endregion
    }
}
