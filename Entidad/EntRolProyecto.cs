using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntRolProyecto
    {
        public EntProyecto eCodigoProyecto { get; set; }
        public EntUsuario eCodigoUsuario { get; set; }
        public EntRol eCodigoRol { get; set; }
    }
}
