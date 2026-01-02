using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList
{
    public class ActividadVm : EntidadAuditable
    {
        public string? Descripcion { get; set; }
    }
}
