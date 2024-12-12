using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntActividad
    {
        public int iCodigo { get; set; }
        public string sNombre { get; set; }
        public string sDescripcion { get; set; }
        public int iProgreso { get; set; } = 0;
        public EntTipoActividad eTipoActividad { get; set; }
        public EntSprint eSprint { get; set; }
        public EntEstado eEstado { get; set; } = new EntEstado { iCodigo = 1 };
    }
}