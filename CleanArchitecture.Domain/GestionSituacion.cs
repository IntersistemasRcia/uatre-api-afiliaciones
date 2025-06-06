using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain;

public class GestionSituacion : EntidadAuditable
{
    public string? Descripcion { get; set; }

    public int GestionEstadoId { get; set; }

    public GestionEstado? GestionEstado { get; set; }
}
