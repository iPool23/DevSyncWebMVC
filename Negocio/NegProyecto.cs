using System.Collections.Generic;

using Datos;
using Entidad;

namespace Negocio
{
    public class NegProyecto
    {
        private DatProyecto objDatos = new DatProyecto();

        public List<EntProyecto> ObtenerProyectosPorUsuario(int codigoUsuario)
        {
            return objDatos.ObtenerProyectosPorUsuario(codigoUsuario);
        }

        public void CrearProyecto(EntProyecto proyecto, string nombreEquipo)
        {
            objDatos.CrearProyecto(proyecto, nombreEquipo);
        }

        public void ActualizarProyecto(EntProyecto proyecto)
        {
            objDatos.ActualizarProyecto(proyecto);
        }

        public EntProyecto ObtenerProyectoPorId(int id)
        {
            return objDatos.ObtenerProyectoPorId(id);
        }

        public void EliminarProyecto(int id)
        {
            objDatos.EliminarProyecto(id);
        }

        public void ActualizarEquipoProyecto(int proyectoId, string nombreEquipo)
        {
            objDatos.ActualizarEquipoProyecto(proyectoId, nombreEquipo);
        }

        public List<EntUsuario> ObtenerUsuariosPorProyecto(int proyectoId)
        {
            return objDatos.ObtenerUsuariosPorProyecto(proyectoId);
        }

        public void AgregarUsuarioAProyecto(int codigoProyecto, int codigoUsuario, int codigoRol)
        {
            objDatos.AgregarUsuarioAProyecto(codigoProyecto, codigoUsuario, codigoRol);
        }

        public bool UsuarioEstaEnProyecto(int codigoProyecto, int codigoUsuario)
        {
            return objDatos.UsuarioEstaEnProyecto(codigoProyecto, codigoUsuario);
        }

    }
}
