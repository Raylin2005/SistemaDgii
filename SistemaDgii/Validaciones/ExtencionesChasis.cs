using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Validaciones
{
    public static class ExtencionesChasis
    {
        public static bool EsChasisValido(this string chasis)
        {
            if (string.IsNullOrWhiteSpace(chasis))
                return false;

            return chasis.Length == 17;
        }
    }
}

