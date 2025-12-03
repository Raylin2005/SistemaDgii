using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Excepciones
{
    public class PlacaDuplicadaException : Exception
    {
        public PlacaDuplicadaException(string mensaje) : base(mensaje)
        {
        }
    }
}
