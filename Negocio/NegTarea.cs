using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    public class NegTarea
    {
        private DatTarea datTarea = new DatTarea();

        public List<EntTarea> ListarPorActividad(int codigoActividad)
        {
            return datTarea.ListarPorActividad(codigoActividad);
        }

        public bool Registrar(EntTarea tarea)
        {
            return datTarea.Registrar(tarea);
        }

        public bool Actualizar(EntTarea tarea)
        {
            return datTarea.Actualizar(tarea);
        }

        public EntTarea ObtenerPorCodigo(int codigo)
        {
            return datTarea.ObtenerPorCodigo(codigo);
        }

        public bool Eliminar(int codigo)
        {
            return datTarea.Eliminar(codigo);
        }
    }
}