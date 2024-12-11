using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class ProyectoModel
    {
        public int iCodigo { get; set; }
        public string sNombre { get; set; }

        public int iProgreso { get; set; }
        public string sDescripcion { get; set; }
        public DateTime dtFechaInicio { get; set; }
        public DateTime dtFechaFin { get; set; }
        public string sImgUrl { get; set; }
        public HttpPostedFileBase ImgFile { get; set; }

        public UsuarioModel eCodigoLider { get; set; }
        public EquipoModel eCodigoEquipo { get; set; }
        public EstadoModel eCodigoEstado { get; set; }
    }
}