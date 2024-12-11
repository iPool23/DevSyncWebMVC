using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatUsuario
    {
        public EntUsuario AutenticarUsuario(string nombreUsuario, string contrasenia)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_Autenticar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@Contrasenia", contrasenia);

                    connection.Open();
                    int resultado = (int)command.ExecuteScalar();

                    if (resultado > 0)
                    {
                        // Obtener la información del usuario
                        using (SqlCommand getUserCommand = new SqlCommand("SP_ObtenerUsuarioPorNombre", connection))
                        {
                            getUserCommand.CommandType = CommandType.StoredProcedure;
                            getUserCommand.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                            using (SqlDataReader reader = getUserCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new EntUsuario
                                    {
                                        iCodigo = (int)reader["codigo"],
                                        sNombreUsuario = (string)reader["nombreUsuario"],
                                        sCorreo = (string)reader["correo"],
                                        sNombres = (string)reader["nombres"],
                                        sApellidos = (string)reader["apellidos"],
                                        sImgUrl = reader["imgUrl"] as string,
                                        eCodigoRol = new EntRol
                                        {
                                            iCodigo = (int)reader["codigoRol"],
                                            sNombre = (string)reader["nombreRol"]
                                        }
                                    };
                                }
                            }
                        }
                    }
                    return null;
                }
            }
        }

        public bool RegistrarUsuario(EntUsuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_RegistrarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.sNombreUsuario);
                    command.Parameters.AddWithValue("@Correo", usuario.sCorreo);
                    command.Parameters.AddWithValue("@Contrasenia", usuario.sContrasenia);
                    command.Parameters.AddWithValue("@Nombres", usuario.sNombres);
                    command.Parameters.AddWithValue("@Apellidos", usuario.sApellidos);
                    command.Parameters.AddWithValue("@ImgUrl", usuario.sImgUrl);
                    command.Parameters.AddWithValue("@CodigoRol", usuario.eCodigoRol.iCodigo);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public EntUsuario ObtenerUsuarioPorCorreo(string correo)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerUsuarioPorCorreo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Correo", correo);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EntUsuario
                            {
                                iCodigo = (int)reader["iCodigo"],
                                sNombreUsuario = reader["sNombreUsuario"].ToString(),
                                sCorreo = reader["sCorreo"].ToString(),
                                sContrasenia = reader["sContrasenia"].ToString(),
                                sNombres = reader["sNombres"].ToString(),
                                sApellidos = reader["sApellidos"].ToString(),
                                sImgUrl = reader["sImgUrl"].ToString(),
                                eCodigoRol = new EntRol
                                {
                                    iCodigo = (int)reader["iCodigoRol"],
                                    sNombre = reader["sNombreRol"].ToString()
                                }
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool UsuarioEstaEnProyecto(int codigoProyecto, int codigoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_UsuarioEstaEnProyecto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoProyecto", codigoProyecto);
                    command.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);

                    connection.Open();
                    int conteo = (int)command.ExecuteScalar();
                    return conteo > 0;
                }
            }
        }
    }
}