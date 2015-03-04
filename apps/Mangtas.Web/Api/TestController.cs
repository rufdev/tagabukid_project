using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace Mangtas.Web.Api
{
    public class TestController : ApiController
    {
        //private readonly IPersonBukService _personService;
        //private readonly IUnitOfWorkAsync _unitofworkAsync;

        //public TestController(IPersonBukService personService, IUnitOfWorkAsync unitofworkAsync)
        //{
        //    _personService = personService;
        //    _unitofworkAsync = unitofworkAsync;
        //}

        // GET: api/Test
        public async Task<IEnumerable<string>> Get()
        {
            //Person person = new Person();

            //person.Name = "RUFINO";
            //person.ObjectState = ObjectState.Added;
            //_personService.Insert(person);
            //await _unitofworkAsync.SaveChangesAsync();

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
