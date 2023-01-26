using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class ActividadController : BaseApiController
    {
        // GET: api/<ActividadController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ActividadController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ActividadController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActividadController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActividadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
