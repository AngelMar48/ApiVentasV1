using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CollectionException : BadRequestException
    {
        public CollectionException()
            : base("No existen Datos registrados")
        {
        }
    }
}
