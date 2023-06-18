using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.UpdateDatosAfip
{
    public class PatchAfiliadoDatosAfipCommand : IRequest<int>
    {        
        [FromQuery(Name = "Id")] public int Id { get; set; }
        [FromBody] public JsonPatchDocument? DatosAfipModel { get; set; }
    }
}
