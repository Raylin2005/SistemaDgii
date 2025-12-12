using SistemaDgii.Modelos;
using SistemaDgii.Excepciones;
using System.Collections.Generic;

namespace SistemaDgii.Repositorio
{
    public static class RepositorioVehiculos
    {
        private static Dictionary<string, Vehiculo> vehiculos = new Dictionary<string, Vehiculo>();

        // Registrar un vehículo
        public static void RegistrarVehiculo(Vehiculo vehiculo)
        {
            // -------------------------------
            // NUEVO: Validación de placa duplicada
            // -------------------------------
            if (vehiculos.ContainsKey(vehiculo.Placa))
                throw new PlacaDuplicadaException($"La placa {vehiculo.Placa} ya está registrada.");

            // -------------------------------
            // NUEVO: Validación de chasis duplicado
            // -------------------------------
            foreach (var v in vehiculos.Values)
            {
                if (v.Chasis == vehiculo.Chasis)
                    throw new ChasisDuplicadoException($"El chasis {vehiculo.Chasis} ya está registrado.");
            }

            vehiculos.Add(vehiculo.Placa, vehiculo);
        }

        // Buscar un vehículo por placa
        public static Vehiculo BuscarVehiculo(string placa)
        {
            if (vehiculos.ContainsKey(placa))
                return vehiculos[placa];

            return null;
        }

        // Transferir vehículo (cambiar dueño)
        public static void TransferirVehiculo(string placa, string nuevoDueno)
        {
            Vehiculo vehiculo = BuscarVehiculo(placa);

            if (vehiculo != null)
            {
                // -------------------------------
                // NUEVO: Validación de multas impagas
                // -------------------------------
                foreach (var infr in vehiculo.ListaDeInfracciones)
                {
                    if (!infr.EstaPagada)
                        throw new MultaImpagaException($"El vehículo con placa {placa} tiene multas pendientes.");
                }

                vehiculo.CambiarDueno(nuevoDueno);
            }
        }

        // Agregar infracción a un vehiculo 
        public static void AgregarInfraccion(string placa, Infraccion infraccion)
        {
            Vehiculo vehiculo = BuscarVehiculo(placa);

            if (vehiculo != null)
            {
                vehiculo.AgregarInfraccion(infraccion);
            }
        }

        // Pagar multa (marcar como pagada)
        public static void PagarMulta(string placa, int indiceMulta)
        {
            Vehiculo vehiculo = BuscarVehiculo(placa);

            if (vehiculo != null)
            {
                List<Infraccion> infracciones = vehiculo.ObtenerInfracciones();

                if (indiceMulta >= 0 && indiceMulta < infracciones.Count)
                {
                    infracciones[indiceMulta].MarcarComoPagada();
                }
            }
        }

        // NUEVO: Método para obtener todos los vehículos
        public static List<Vehiculo> ObtenerTodos()
        {
            return new List<Vehiculo>(vehiculos.Values);
        }
    }
}

