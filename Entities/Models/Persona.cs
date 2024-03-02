using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public  class Persona
    {
        [Column("PersonaId")]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }
        [Required]
        public string? Identificacion { get; set; }

        public ICollection<Factura>? Facturas { get; set; }
    }
}
