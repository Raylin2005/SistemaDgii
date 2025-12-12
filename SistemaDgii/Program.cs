using SistemaDgii.Excepciones;
using SistemaDgii.Modelos;
using SistemaDgii.Repositorio;
using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE VEHÍCULOS DGII ===");
            Console.WriteLine("1. Registrar vehículo");
            Console.WriteLine("2. Transferir vehículo");
            Console.WriteLine("3. Buscar vehículo por placa");
            Console.WriteLine("4. Calcular marbete");
            Console.WriteLine("5. Ver infracciones de un vehículo");
            Console.WriteLine("6. Registrar infracción");
            Console.WriteLine("7. Pagar multa");
            Console.WriteLine("8. Reporte de vehículos");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione opción: ");

            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1: RegistrarVehiculo(); break;
                case 2: TransferirVehiculo(); break;
                case 3: BuscarVehiculo(); break;
                case 4: CalcularMarbete(); break;
                case 5: VerInfracciones(); break;
                case 6: RegistrarInfraccion(); break;
                case 7: PagarMulta(); break;
                case 8: ReporteVehiculos(); break;
                case 9: break;
                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != 9);
    }

    // ============================================================
    // 1. REGISTRAR VEHÍCULO
    // ============================================================

    static void RegistrarVehiculo()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR VEHÍCULO ===");

        Console.WriteLine("Seleccione el tipo:");
        Console.WriteLine("1. Automóvil");
        Console.WriteLine("2. Motocicleta");
        Console.WriteLine("3. Camión");
        Console.WriteLine("4. Autobús");
        Console.Write("Opción: ");

        int tipo = int.Parse(Console.ReadLine());

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        Console.Write("Marca: ");
        string marca = Console.ReadLine().Trim();

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine().Trim();

        Console.Write("Año: ");
        int año = int.Parse(Console.ReadLine());

        Console.Write("Chasis: ");
        string chasis = Console.ReadLine().Trim().ToUpper();

        Console.Write("Dueño: ");
        string dueño = Console.ReadLine().Trim().ToUpper();

        // Validaciones básicas (B)
        if (string.IsNullOrWhiteSpace(placa) ||
            string.IsNullOrWhiteSpace(chasis))
        {
            Console.WriteLine("Datos inválidos.");
            Console.ReadKey();
            return;
        }

        try
        {
            Vehiculo vehiculo = tipo switch
            {
                1 => new Automovil(placa, marca, modelo, año, chasis, dueño),
                2 => new Motocicleta(placa, marca, modelo, año, chasis, dueño),
                3 => new Camion(placa, marca, modelo, año, chasis, dueño),
                4 => new Autobus(placa, marca, modelo, año, chasis, dueño),
                _ => null
            };

            RepositorioVehiculos.RegistrarVehiculo(vehiculo);

            Console.WriteLine("Vehículo registrado correctamente.");
        }
        catch (PlacaDuplicadaException ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
        catch (ChasisDuplicadoException ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.ReadKey();
    }

    // ============================================================
    // 2. TRANSFERIR VEHÍCULO
    // ============================================================

    static void TransferirVehiculo()
    {
        Console.Clear();
        Console.WriteLine("=== TRANSFERIR VEHÍCULO ===");

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        Console.Write("Nuevo dueño: ");
        string nuevo = Console.ReadLine().Trim().ToUpper();

        try
        {
            RepositorioVehiculos.TransferirVehiculo(placa, nuevo);
            Console.WriteLine("Transferencia realizada.");
        }
        catch (MultaImpagaException ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.ReadKey();
    }

    // ============================================================
    // 3. BUSCAR VEHÍCULO
    // ============================================================

    static void BuscarVehiculo()
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR VEHÍCULO ===");

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        var v = RepositorioVehiculos.BuscarVehiculo(placa);

        if (v == null)
            Console.WriteLine("No encontrado.");
        else
            Console.WriteLine(v.ToString());

        Console.ReadKey();
    }

    // ============================================================
    // 4. CALCULAR MARBETE
    // ============================================================

    static void CalcularMarbete()
    {
        Console.Clear();
        Console.WriteLine("=== CALCULAR MARBETE ===");

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        var v = RepositorioVehiculos.BuscarVehiculo(placa);

        if (v == null)
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
        else
        {
            try
            {
                decimal monto = v.CalcularMarbete();
                Console.WriteLine("Monto del marbete: " + monto);
            }
            catch (MultaImpagaException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        Console.ReadKey();
    }

    // ============================================================
    // 5. VER INFRACCIONES
    // ============================================================

    static void VerInfracciones()
    {
        Console.Clear();
        Console.WriteLine("=== INFRACCIONES ===");

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        var v = RepositorioVehiculos.BuscarVehiculo(placa);

        if (v == null)
        {
            Console.WriteLine("Vehículo no encontrado.");
            Console.ReadKey();
            return;
        }

        var lista = v.ObtenerInfracciones();

        if (lista.Count == 0)
        {
            Console.WriteLine("No tiene infracciones.");
        }
        else
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i}. {lista[i]}");
            }
        }

        Console.ReadKey();
    }

    // ============================================================
    // 6. REGISTRAR INFRACCIÓN
    // ============================================================

    static void RegistrarInfraccion()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR INFRACCIÓN ===");

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        Console.Write("Tipo: ");
        string tipo = Console.ReadLine().Trim();

        Console.Write("Fecha (yyyy-mm-dd): ");
        DateTime fecha = DateTime.Parse(Console.ReadLine());

        Console.Write("Monto: ");
        decimal monto = decimal.Parse(Console.ReadLine());

        var infr = new Infraccion(tipo, fecha, monto, false);

        RepositorioVehiculos.AgregarInfraccion(placa, infr);

        Console.WriteLine("Infracción registrada.");
        Console.ReadKey();
    }

    // ============================================================
    // 7. PAGAR MULTA
    // ============================================================

    static void PagarMulta()
    {
        Console.Clear();
        Console.WriteLine("=== PAGAR MULTA ===");

        Console.Write("Placa: ");
        string placa = Console.ReadLine().Trim().ToUpper();

        var v = RepositorioVehiculos.BuscarVehiculo(placa);

        if (v == null)
        {
            Console.WriteLine("No encontrado.");
            Console.ReadKey();
            return;
        }

        var lista = v.ObtenerInfracciones();

        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{i}. {lista[i]}");
        }

        Console.Write("Seleccione índice: ");
        int indice = int.Parse(Console.ReadLine());

        try
        {
            RepositorioVehiculos.PagarMulta(placa, indice);
            Console.WriteLine("Multa pagada.");
        }
        catch (MultaImpagaException ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }

        Console.ReadKey();
    }

    // ============================================================
    // 8. REPORTE DE VEHÍCULOS
    // ============================================================

    static void ReporteVehiculos()
    {
        Console.Clear();
        Console.WriteLine("=== REPORTE DE VEHÍCULOS ===");

        var lista = RepositorioVehiculos.ObtenerTodos();

        foreach (var v in lista)
        {
            Console.WriteLine($"{v.Placa} | {v.GetType().Name} | {v.Dueno} | Infracciones: {v.ObtenerInfracciones().Count}");
        }

        Console.ReadKey();
    }
}
