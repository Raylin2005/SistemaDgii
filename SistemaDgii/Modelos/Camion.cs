using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SistemaDgii.Interfaces;

namespace SistemaDgii.Modelos
{
    public class Camion : Vehiculo, IRegistrable, ITransferible, IMultable
    {
        // Constructor vacío
        public Camion()
        {
        }

        // Constructor con parámetros
        public Camion(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // ======================
        // MARBETE - POLIMORFISMO
        // ======================
        public override decimal CalcularMarbete()
        {
            return 2500m;  // monto estándar para camiones
        }

        // ======================
        // IMPLEMENTACIÓN DE INTERFACES
        // ======================

        public void RegistrarVehiculo()
        {
            // No lleva lógica real en el modelo.
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

