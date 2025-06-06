using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain;

public class GestionEstado : EntidadAuditable
{
    public string? Descripcion { get; set; }
}
