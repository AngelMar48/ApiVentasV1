using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class PersonaManipulate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        [Required]
        public string? Identificacion { get; set; }
    }
}
