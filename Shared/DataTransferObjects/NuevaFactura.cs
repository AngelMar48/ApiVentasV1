using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class  FacturaSimple{
        public PersonaManipulate persona { get; set; }
        public FacturaSimple factura { get; set; }
    }

    public class NuevaFactura
{
       
      
        public string? Fecha { get; set; }
        public string? Monto { get; set; }
        public Guid PersonaId { get; set; }
    }
}
