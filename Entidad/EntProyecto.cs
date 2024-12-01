using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntProyecto
    {
        public int iCodigo { get; set; }
        public string sNombre { get; set; }
        public int iProgreso { get; set; }
        public string sDescripcion { get; set; }
        public DateTime dtFechaInicio { get; set; }
        public DateTime dtFechaFin { get; set; }
        public string sImgUrl { get; set; }
        public EntUsuario eCodigoLider {  get; set; }
        public EntEquipo eCodigoEquipo { get; set; }
        public EntEstado eCodigoEstado { get; set; }
    }
}
