using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    public class NegActividad
    {
        private DatActividad datActividad = new DatActividad();

        public List<EntActividad> ListarPorSprint(int codigoSprint)
        {
            return datActividad.ListarPorSprint(codigoSprint);
        }

        public bool Registrar(EntActividad actividad)
        {
            return datActividad.Registrar(actividad);
        }

        public bool Actualizar(EntActividad actividad)
        {
            return datActividad.Actualizar(actividad);
        }

        public EntActividad ObtenerPorCodigo(int codigo)
        {
            return datActividad.ObtenerPorCodigo(codigo);
        }

        public bool Eliminar(int codigo)
        {
            return datActividad.Eliminar(codigo);
        }
    }
}