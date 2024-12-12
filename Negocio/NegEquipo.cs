using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    public class NegEquipo
    {
        private DatEquipo datEquipo = new DatEquipo();

        public EntEquipo ObtenerEquipoPorId(int codigoEquipo)
        {
            return datEquipo.ObtenerEquipoPorId(codigoEquipo);
        }
        public List<EntUsuario> ObtenerUsuariosPorEquipo(int codigoEquipo)
        {
            return datEquipo.ObtenerUsuariosPorEquipo(codigoEquipo);
        }
    }
}
