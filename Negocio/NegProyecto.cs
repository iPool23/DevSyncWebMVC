using System;
using System.Collections.Generic;

using Datos;
using Entidad;

namespace Negocio
{
    public class NegProyecto
    {
        private DatProyecto objDatos = new DatProyecto();
        private NegUsuario negUsuario = new NegUsuario();

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

        public bool UsuarioEstaEnProyecto(int codigoProyecto, int codigoUsuario)
        {
            return objDatos.UsuarioEstaEnProyecto(codigoProyecto, codigoUsuario);
        }

        public void AgregarUsuarioAProyecto(int codigoProyecto, int codigoUsuario, int codigoRol)
        {
            var equipo = objDatos.ObtenerEquipoDeProyecto(codigoProyecto);
            if (equipo == null)
                throw new Exception("El proyecto no tiene un equipo asignado.");

            // Agregar usuario al equipo
            negUsuario.AgregarUsuarioAEquipo(equipo.iCodigo, codigoUsuario);

            // Asignar rol en el proyecto
            objDatos.AsignarRolUsuarioEnProyecto(codigoProyecto, codigoUsuario, codigoRol);
        }

        public void AsignarRolUsuarioEnProyecto( int codigoProyecto, int codigoUsuario, int codigoRol)
        {
            objDatos.AsignarRolUsuarioEnProyecto(codigoProyecto, codigoUsuario, codigoRol);
        }

        public void EliminarUsuarioDeProyecto(int proyectoId, int usuarioId)
        {
            var equipo = objDatos.ObtenerEquipoDeProyecto(proyectoId);
            if (equipo == null)
                throw new Exception("El proyecto no tiene un equipo asignado.");

            objDatos.EliminarUsuarioDeEquipoYProyecto(equipo.iCodigo, usuarioId, proyectoId);
        }

    }
}
