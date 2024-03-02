using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Factura
    {
        [Column("FacturaId")]
        public Guid Id { get; set; }
        public string? Fecha { get; set; }
        public string? Monto { get; set; }

        [ForeignKey(nameof(Persona))]
        public Guid PersonaId { get; set; }
        public Persona? Persona { get; set; }
    }
}
