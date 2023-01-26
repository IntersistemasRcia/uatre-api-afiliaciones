using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class SeccionalController : BaseApiController
    {
        // GET: api/<SeccionalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SeccionalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SeccionalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeccionalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeccionalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
