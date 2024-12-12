using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidad
{
    public class EntSprint
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int progreso { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public EntUsuario objUsuario { get; set; }
        public EntProyecto objProyecto { get; set; }



    }
}
