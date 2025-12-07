using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
    public class Infraccion
    {
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public bool EstaPagada { get; set; }

        public Infraccion()
        {
        }

        public Infraccion(string tipo, DateTime fecha, decimal monto, bool estaPagada)
        {
            Tipo = tipo;
            Fecha = fecha;
            Monto = monto;
            EstaPagada = estaPagada;
        }

        public void MarcarComoPagada()
        {
            EstaPagada = true;
        }

        public override string ToString()
        {
            string estado = EstaPagada ? "Pagada" : "Pendiente";

            return $"Tipo: {Tipo}\n" +
                   $"Fecha: {Fecha.ToShortDateString()}\n" +
                   $"Monto: {Monto}\n" +
                   $"Estado: {estado}";
        }
    }
}
