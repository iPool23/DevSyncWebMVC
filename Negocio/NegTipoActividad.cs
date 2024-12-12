using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    public class NegTipoActividad
    {
        private DatTipoActividad datTipoActividad = new DatTipoActividad();

        public List<EntTipoActividad> Listar()
        {
            return datTipoActividad.Listar();
        }
    }
}