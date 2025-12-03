using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
    public class Autobus : Vehiculo
    {
        // Constructor vacío
        public Autobus()
        {
        }

        // Constructor con parámetros (mismos de Vehiculo)
        public Autobus(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // Método CalcularMarbete sobrescrito
        public override decimal CalcularMarbete()
        {
            return 0; // Solo la firma, sin lógica
        }
    }
}
