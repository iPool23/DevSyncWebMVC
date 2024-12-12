using System;
using Entidad;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Datos
{
    public class DatEquipo
    {
        public EntEquipo ObtenerEquipoPorId(int codigoEquipo)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                conn.Open();
                string query = "SELECT * FROM equipo WHERE codigo = @CodigoEquipo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CodigoEquipo", codigoEquipo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new EntEquipo
                        {
                            iCodigo = (int)reader["codigo"],
                            sNombre = reader["nombre"].ToString(),
                            sImgUrl = reader["imgUrl"] != DBNull.Value ? reader["imgUrl"].ToString() : null
                        };
                    }
                }
            }
            return null;
        }

        public List<EntUsuario> ObtenerUsuariosPorEquipo(int codigoEquipo)
        {
            var usuarios = new List<EntUsuario>();

            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                conn.Open();
                string query = @"
                    SELECT u.*, r.nombre AS nombreRol
                    FROM usuario u
                    INNER JOIN equipo_usuario eu ON u.codigo = eu.codigoUsuario
                    INNER JOIN rol r ON u.codigoRol = r.codigo
                    WHERE eu.codigoEquipo = @CodigoEquipo";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CodigoEquipo", codigoEquipo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new EntUsuario
                        {
                            iCodigo = (int)reader["codigo"],
                            sNombreUsuario = reader["nombreUsuario"].ToString(),
                            sCorreo = reader["correo"].ToString(),
                            sNombres = reader["nombres"] != DBNull.Value ? reader["nombres"].ToString() : null,
                            sApellidos = reader["apellidos"] != DBNull.Value ? reader["apellidos"].ToString() : null,
                            eCodigoRol = new EntRol
                            {
                                iCodigo = (int)reader["codigoRol"],
                                sNombre = reader["nombreRol"].ToString()
                            },
                            sImgUrl = reader["imgUrl"] != DBNull.Value ? reader["imgUrl"].ToString() : null
                        };
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }
    }
}
