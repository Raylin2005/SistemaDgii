using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace SistemaDgii.Validaciones
{
    public class ValidadorPlacas
    {
        public static bool EsPlacaValida(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            // A123456, M123456, C123456
            string patron = @"^[AMC][0-9]{6}$";

            return Regex.IsMatch(placa, patron);
        }
    }
}
