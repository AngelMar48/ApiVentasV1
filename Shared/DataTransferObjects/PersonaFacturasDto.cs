using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class PersonaFacturasDto
    {
        //public Guid Id { get; set; }
        public string? NombreCompleto { get; set; }

        //public string? Identificacion { get; set; }

        public IEnumerable<FacturaDto>? Facturas { get; init; }

    }
}
