using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Responses;

public class SeccionalEstadoResponse : EntidadAuditable
{    
    public string Descripcion { get; set; } = string.Empty;
}
