using System.Collections.Generic;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatRol
    {
        public List<EntRol> ObtenerTodosLosRoles()
        {
            List<EntRol> roles = new List<EntRol>();

            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                string query = "SELECT codigo, nombre FROM rol";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new EntRol
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombre = reader["nombre"].ToString()
                            });
                        }
                    }
                }
            }
            return roles;
        }
    }
}
