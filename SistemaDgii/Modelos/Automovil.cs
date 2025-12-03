using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
    public class Automovil : Vehiculo
    {
        // Constructor vacío
        public Automovil()
        {
        }

        // Constructor con parámetros (los mismos que Vehiculo)
        public Automovil(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // Método sobrescrito (solo la firma)
        public override decimal CalcularMarbete()
        {
            // Aquí NO pones lógica porque no la piden
            return 0;
        }
    }
}
