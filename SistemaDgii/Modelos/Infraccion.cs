using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Modelos
{
    public class Infraccion
    {
        // Propiedades recomendadas
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public bool EstaPagada { get; set; }

        // Constructor vacío
        public Infraccion()
        {
        }

        // Constructor con parámetros
        public Infraccion(string tipo, DateTime fecha, decimal monto, bool estaPagada)
        {
            Tipo = tipo;
            Fecha = fecha;
            Monto = monto;
            EstaPagada = estaPagada;
        }

        // Método para marcar como pagada
        public void MarcarComoPagada()
        {
            // Solo firma, sin lógica real
            EstaPagada = true;
        }

        // ToString (solo firma)
        public override string ToString()
        {
            return "";
        }
    }
}
