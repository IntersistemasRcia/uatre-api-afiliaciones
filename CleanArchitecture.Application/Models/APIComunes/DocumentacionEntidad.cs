using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Models.APIComunes
{
    public class DocumentacionEntidad
    {        
        public int Id { get; set; }
        public string? EntidadTipo { get; set; }
        public int EntidadId { get; set; }
        public int RefTipoDocumentacionId { get; set; }
        public Byte[]? Archivo { get; set; }
        //public string? NombreArchivo { get; set; }
        public string? Observaciones { get; set; }       
    }
}
