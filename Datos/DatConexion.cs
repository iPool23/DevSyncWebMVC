using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace Datos
{
    public class DatConexion
    {
        public static string sCadena = ConfigurationManager.ConnectionStrings["CnDevSync"].ToString();
    }
}
