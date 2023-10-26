using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class SeccionalContacto : EntidadAuditable
    {
        public int SeccionalId { get; set; }
        public Seccional? Seccional { get; set; }
        [StringLength(1)]
        public SeccionalContactoTipo Tipo { get; set; }
        [StringLength(500)]        
        public string? Detalle { get; set; }
    }

    public enum SeccionalContactoTipo
    {
        TelefonoFijo = 'F',
        TelefonoCelular = 'C',
        TelefonoFax = 'F',
        Contacto = 'O',
        Email = 'E',
        Otros = 'T'
    }
}
