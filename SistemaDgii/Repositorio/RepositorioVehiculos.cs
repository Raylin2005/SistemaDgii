using SistemaDgii.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Repositorio
{
    public class RepositorioVehiculos
    {
        // Dictionary para almacenar vehículos
        // Clave: placa | Valor: vehículo
        private Dictionary<string, Vehiculo> vehiculos;

        // Constructor (solo inicialización, sin lógica extra)
        public RepositorioVehiculos()
        {
            vehiculos = new Dictionary<string, Vehiculo>();
        }

        // Métodos solicitados (solo firmas)

        // Registrar un vehículo en el diccionario
        public void RegistrarVehiculo(Vehiculo vehiculo)
        {
        }

        // Buscar un vehículo por placa
        public Vehiculo BuscarVehiculo(string placa)
        {
            return null;
        }

        // Transferir vehículo (cambiar dueño)
        public void TransferirVehiculo(string placa, string nuevoDueno)
        {
        }

        // Agregar infracción a un vehículo
        public void AgregarInfraccion(string placa, Infraccion infraccion)
        {
        }

        // Pagar multa (marcar como pagada)
        public void PagarMulta(string placa, int indiceMulta)
        {
        }
    }
}
