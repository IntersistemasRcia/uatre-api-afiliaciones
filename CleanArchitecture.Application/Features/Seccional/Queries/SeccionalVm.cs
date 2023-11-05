using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.Seccional.Queries
{
    public class SeccionalVm : EntidadAuditable
    {
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Domicilio { get; set; }        
        public string? Estado { get; set; }
        public string? Observaciones { get; set; }
        public int RefLocalidadesId { get; set; }
        public string? LocalidadNombre { get; set; }
        public int LocalidadCodPostal { get; set; }
        public int RefDelegacionId { get; set; }
        public string? RefDelegacionDescripcion { get; set; }
        public ICollection<SeccionalLocalidadVm>? SeccionalLocalidad { get; set; }
    }

    public class SeccionalLocalidadVm
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
