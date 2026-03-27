using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.Puesto.Queries
{
    public class PuestoVm : EntidadAuditable
    {
        public string? Descripcion { get; set; }
    }
}
