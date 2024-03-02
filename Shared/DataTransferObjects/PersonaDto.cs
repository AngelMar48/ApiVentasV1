using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class PersonaDto
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public string? Identificacion { get; set; }

    }
}
