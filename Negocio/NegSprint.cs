using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegSprint
    {
        private DatSprint objSprint = new DatSprint();

        public List<EntSprint> listar(int codigoProyecto)
        {
            return objSprint.Listar(codigoProyecto);
        }
        public List<EntSprint> ObtenerPorCodigo (int codigoSprint)
        {
            return objSprint.ObtenerPorCodigo(codigoSprint);
        }
        public bool registrar(EntSprint entSprint)
        {
            return objSprint.registrar(entSprint);
        }
        public bool editar(EntSprint entSprint)
        {
            return objSprint.editar(entSprint);
        }
        public bool Eliminar(int codigo)
        {
            return objSprint.Eliminar(codigo);
        }
    }
}
