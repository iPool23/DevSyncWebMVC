using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntTarea
    {
        public int iCodigo { get; set; }
        public string sNombre { get; set; }
        public string sDescripcion { get; set; }
        public DateTime dtFechaInicio { get; set; }
        public DateTime? dtFechaActualizacion { get; set; }
        public DateTime dtFechaVencimiento { get; set; }
        public int iPrioridad { get; set; }
        public int iProgreso { get; set; }
        public EntUsuario eUsuario { get; set; }
        public EntEstado eEstado { get; set; }
        public EntActividad eActividad { get; set; }
    }
}