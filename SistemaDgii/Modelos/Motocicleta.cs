using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDgii.Interfaces;

namespace SistemaDgii.Modelos
{
    public class Motocicleta : Vehiculo, IRegistrable, ITransferible, IMultable
    {
        // Constructor vacío
        public Motocicleta()
        {
        }

        // Constructor con parámetros
        public Motocicleta(string placa, string marca, string modelo, int año, string chasis, string dueno)
            : base(placa, marca, modelo, año, chasis, dueno)
        {
        }

        // ======================
        // POLIMORFISMO - MARBETE
        // ======================
        public override decimal CalcularMarbete()
        {
            // Lógica simple y estándar para motos
            return 600m;
        }

        // ======================
        // IMPLEMENTACIÓN DE INTERFACES
        // ======================

        // Registrar — no lleva lógica porque el registro real lo hace el repositorio/servicio
        public void RegistrarVehiculo()
        {
        }

        // Transferir — usa la lógica existente en Vehiculo
        public void Transferir(string nuevoDueno)
        {
            CambiarDueno(nuevoDueno);
        }

        // Registrar infracción — usa el método de Vehiculo
        public void RegistrarInfraccion(Infraccion infraccion)
        {
            AgregarInfraccion(infraccion);
        }

        // Pagar multa — esta lógica YA existe en la clase Infraccion
        public void PagarMulta(Infraccion infraccion)
        {
            infraccion.EstaPagada = true;
        }
    }
}

