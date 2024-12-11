using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntUsuario
    {
        public int iCodigo { get; set; }
        public string sNombreUsuario { get; set; }
        public string sCorreo { get; set; }
        public string sContrasenia { get; set; }
        public string sNombres { get; set; }
        public string sApellidos { get; set; }
        public string sImgUrl { get; set; }
        public EntRol eCodigoRol { get; set; }
    }
}