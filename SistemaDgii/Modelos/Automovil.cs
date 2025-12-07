using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDgii.Interfaces;

namespace SistemaDgii.Modelos
{
    public class Automovil : Vehiculo, IRegistrable, ITransferible, IMultable
    {
        // Constructor vacío
        public Automovil()
        {
        }

        // Constructor con parámetros
        public Automovil(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // ======================
        // POLIMORFISMO - MARBETE
        // ======================
        public override decimal CalcularMarbete()
        {
            return 1500m; // monto típico para automóvil
        }

        // ======================
        // IMPLEMENTACIÓN DE INTERFACES
        // ======================

        public void RegistrarVehiculo()
        {
            // No tiene lógica aquí; el registro real lo hará el repositorio/servicio.
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
