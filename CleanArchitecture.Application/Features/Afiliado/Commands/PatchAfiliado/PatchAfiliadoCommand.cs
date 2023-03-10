using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.PatchAfiliado
{
    public class PatchAfiliadoCommand : IRequest<int>
    {
        [FromQuery(Name = "Id")] public int Id { get; set; }
        [FromBody] public JsonPatchDocument? model { get; set; }
    }
}
