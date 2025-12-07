using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDgii.Interfaces;

namespace SistemaDgii.Modelos
{
    public class Autobus : Vehiculo, IRegistrable, ITransferible, IMultable
    {
        // Constructor vacío
        public Autobus()
        {
        }

        // Constructor con parámetros
        public Autobus(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // ======================
        // POLIMORFISMO - MARBETE
        // ======================
        public override decimal CalcularMarbete()
        {
            return 3000m; // monto típico para autobuses
        }

        // ======================
        // IMPLEMENTACIÓN DE INTERFACES
        // ======================

        public void RegistrarVehiculo()
        {
            // No se implementa lógica aquí; el servicio/menú maneja el registro real.
        }

        public void Transferir(string nuevoDueno)
        {
            CambiarDueno(nuevoDueno);
        }

        public void RegistrarInfraccion(Infraccion infraccion)
        {
            AgregarInfraccion(infraccion);
        }

        public void PagarMulta(Infraccion infraccion)
        {
            infraccion.EstaPagada = true;
        }
    }
}

