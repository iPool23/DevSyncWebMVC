using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class RolProyectoModel
    {
        public ProyectoModel eCodigoProyecto { get; set; }
        public UsuarioModel eCodigoUsuario { get; set; }
        public RolModel eCodigoRol { get; set; }
    }
}