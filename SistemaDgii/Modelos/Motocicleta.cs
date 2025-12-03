using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
   public class Motocicleta : Vehiculo
    {
        // Constructor vacío
        public Motocicleta()
        {
        }

        // Constructor con parámetros (mismos de Vehiculo)
        public Motocicleta(string placa, string marca, string modelo, int año, string chasis, string dueno)
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
