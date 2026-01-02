using CleanArchitecture.Domain.Commom;
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
        public string? NombreArchivo { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedObs { get; set; }
        public Guid GUID { get; set; }
    }
}
