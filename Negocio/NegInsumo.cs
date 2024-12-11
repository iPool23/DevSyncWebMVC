using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegInsumo
    {
        private DatInsumo obj = new DatInsumo();
        public List<EntInsumo> listar(int codigo)
        {
            return obj.Listar(codigo);
        }
        public List<EntInsumo> ObtenerPorCodigo(int codigo)
        {
            return obj.ObtenerPorCodigo(codigo);
        }
        public bool registrar(EntInsumo entSprint)
        {
            return obj.registrar(entSprint);
        }
        public bool editar(EntInsumo entSprint)
        {
            return obj.editar(entSprint);
        }
        public bool Eliminar(int codigo)
        {
            return obj.Eliminar(codigo);
        }
    }
}
