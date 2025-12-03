using SistemaDgii.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDgii.Interfaces
{
    internal interface IMultable
    {
        void AgregarInfraccion(Infraccion infraccion);
        List<Infraccion> ObtenerInfracciones();
    }
}
