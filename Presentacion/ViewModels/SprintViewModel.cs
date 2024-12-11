using System;

namespace Presentacion.ViewModels
{
    public class SprintViewModel
    {
        public int? codigo { get; set; } 
        public string nombre { get; set; }
        public int progreso { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int codigoProyecto { get; set; }
    }
}
