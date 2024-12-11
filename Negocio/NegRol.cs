using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;

namespace Negocio
{
    public class NegRol
    {
        private DatRol objDatos = new DatRol();

        public List<EntRol> ObtenerTodosLosRoles()
        {
            return objDatos.ObtenerTodosLosRoles();
        }
    }
}
