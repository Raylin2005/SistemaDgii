using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Excepciones
{
    public class ChasisDuplicadoException : Exception
    {
        public ChasisDuplicadoException(string mensaje) : base(mensaje)
        {
        }
    }
}
