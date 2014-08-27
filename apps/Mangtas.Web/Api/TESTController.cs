using System.Collections.Generic;
using System.Web.Http;

namespace Mangtas.Web.Api
{
    public class TESTController : ApiController
    {
        // GET: api/TEST
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TEST/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TEST
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TEST/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TEST/5
        public void Delete(int id)
        {
        }
    }
}
