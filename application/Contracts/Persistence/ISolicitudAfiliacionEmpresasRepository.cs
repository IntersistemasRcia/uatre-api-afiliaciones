using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ISolicitudAfiliacionEmpresasRepository
    {
        Task CrearSolicitudAfiliacionEmpresas(SolicitudAfiliacionEmpresas solicitud);
        //Task AgregarSolicitudAfiliacionEmpresasDetalle(SolicitudAfiliacionEmpresasDetalle detalle, int solicitudId);
        Task<SolicitudAfiliacionEmpresasDetalle>? GetLastDetalleBySolicitudId(int solicitudId);
    }
}
