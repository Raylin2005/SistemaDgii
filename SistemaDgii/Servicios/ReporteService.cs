using SistemaDgii.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDgii.Servicios
{
    internal class ReporteService
    {
        // ===========================================
        // REPORTE 1: Vehículos por año
        // ===========================================
        // Devuelve todos los vehículos que coincidan con el año dado.
        public List<Vehiculo> ObtenerVehiculosPorAnio(List<Vehiculo> lista, int anio)
        {
            return lista
                .Where(v => v.Anio == anio)
                .ToList();
        }

        // ===========================================
        // REPORTE 2: Marca más común
        // ===========================================
        // Retorna la marca que más aparece en la lista.
        public string ObtenerMarcaMasComun(List<Vehiculo> lista)
        {
            return lista
                .GroupBy(v => v.Marca)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        // ===========================================
        // REPORTE 3: Cantidad de infracciones por tipo
        // ===========================================
        // Devuelve un diccionario: { Tipo : Cantidad }
        public Dictionary<string, int> ObtenerInfraccionesPorTipo(List<Vehiculo> lista)
        {
            return lista
                .SelectMany(v => v.ObtenerInfracciones())        // Unir todas las infracciones
                .GroupBy(i => i.Tipo)                           // Agrupación por tipo
                .ToDictionary(g => g.Key, g => g.Count());      // Convertir a diccionario
        }
    }
}

