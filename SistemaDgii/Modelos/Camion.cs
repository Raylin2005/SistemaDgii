using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
    public class Camion : Vehiculo
    {
        // Constructor vacío
        public Camion()
        {
        }

        // Constructor con parámetros (mismos de Vehiculo)
        public Camion(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // Método CalcularMarbete sobrescrito (solo firma)
        public override decimal CalcularMarbete()
        {
            return 0; // Solo la firma, sin lógica
        }
    }
}
