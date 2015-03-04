using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CoreService.Domain;
using CoreService.Service;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace CoreService
{
    public class TestWebApiController : ApiController
    {
        private readonly IPersonBukService _personService;
        private readonly IUnitOfWorkAsync _unitofworkAsync;

        public TestWebApiController(IPersonBukService personService, IUnitOfWorkAsync unitofworkAsync)
        {
            _personService = personService;
            _unitofworkAsync = unitofworkAsync;
        }

        // GET: api/Test
        public async Task<IEnumerable<string>> Get()
        {
            Person person = new Person();

            person.Name = "RUFINO";
            person.ObjectState = ObjectState.Added;
            _personService.Insert(person);
            await _unitofworkAsync.SaveChangesAsync();

            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
