using CleanArchitecture.Application.Features.Sexo.Queries;
using CleanArchitecture.Application.Features.Sexo.Queries.GetSexoList;
using CleanArchitecture.Application.Features.Sexo.Queries.GetSexoSingle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class SexoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SexoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SexoController>
        [HttpGet(Name = "GetSexoAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<SexoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SexoVm>>> GetSexoAll()
        {
            var query = new GetSexoListQuery();
            var videos = await _mediator.Send(query);

            return Ok(videos);
        }

        // GET: api/<SexoController>/1
        [HttpGet("{id}", Name = "GetSexoById")]
        //[Authorize]
        [ProducesResponseType(typeof(SexoVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SexoVm>>> GetSexoById(int pId)
        {
            var query = new GetSexoSingleQuery(pId);
            var videos = await _mediator.Send(query);

            return Ok(videos);
        }

        // POST api/<SexoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SexoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SexoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
