using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain;

public class GestionSubRubro : EntidadAuditable
{
    public string? Descripcion { get; set; }

    public int GestionRubroId { get; set; }
    public GestionRubro? GestionRubro { get; set; }
}
