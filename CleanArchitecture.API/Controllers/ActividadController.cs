using CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class ActividadController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ActividadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetActividadesAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<ActividadVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<ActividadVm>>> GetActividadesAll()
        {
            var query = new GetActividadesListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }

    //// GET api/<ActividadController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<ActividadController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<ActividadController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<ActividadController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
    }
}
