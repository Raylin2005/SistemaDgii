using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
    public abstract class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Chasis { get; set; }
        public string Dueno { get; set; }

        public List<Infraccion> ListaDeInfracciones { get; private set; }

        public Vehiculo()
        {
            ListaDeInfracciones = new List<Infraccion>();
        }

        public Vehiculo(string placa, string marca, string modelo, int año, string chasis, string dueno)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Anio = año;
            Chasis = chasis;
            Dueno = dueno;

            ListaDeInfracciones = new List<Infraccion>();
        }

        // Métodos abstractos / virtuales
        public abstract decimal CalcularMarbete();

        public override string ToString()
        {
            return $"Placa: {Placa}\n" +
                   $"Marca: {Marca}\n" +
                   $"Modelo: {Modelo}\n" +
                   $"Año: {Anio}\n" +
                   $"Chasis: {Chasis}\n" +
                   $"Dueño: {Dueno}";
        }


        public void AgregarInfraccion(Infraccion infraccion)
        {
            ListaDeInfracciones.Add(infraccion);
        }

        public List<Infraccion> ObtenerInfracciones()
        {
            return ListaDeInfracciones;
        }

        public void CambiarDueno(string nuevoDueno)
        {
            Dueno = nuevoDueno;
        }
    }
}
      

