using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;

namespace Negocio
{
    public class NegProyecto
    {
        private DatProyecto objDatos = new DatProyecto();

        public List<EntProyecto> Listar()
        {
            return objDatos.Listar();
        }
    }
}
