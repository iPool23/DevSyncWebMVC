using System.Collections.Generic;
using System;
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
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerUsuarioPorCorreo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Correo", correo);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EntUsuario
                            {
                                iCodigo = (int)reader["iCodigo"],
                                sNombreUsuario = reader["sNombreUsuario"].ToString(),
                                sCorreo = reader["sCorreo"].ToString(),
                                sNombres = reader["sNombres"]?.ToString(),
                                sApellidos = reader["sApellidos"]?.ToString(),
                                sImgUrl = reader["sImgUrl"]?.ToString(),
                                eCodigoRol = new EntRol
                                {
                                    iCodigo = (int)reader["iCodigoRol"],
                                    sNombre = reader["sNombreRol"].ToString()
                                }
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public bool UsuarioEstaEnEquipo(int codigoEquipo, int codigoUsuario)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM equipo_usuario WHERE codigoEquipo = @EquipoId AND codigoUsuario = @UsuarioId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EquipoId", codigoEquipo);
                cmd.Parameters.AddWithValue("@UsuarioId", codigoUsuario);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void AgregarUsuarioAEquipo(int codigoEquipo, int codigoUsuario)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO equipo_usuario (codigoEquipo, codigoUsuario) VALUES (@EquipoId, @UsuarioId)";
                        using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@EquipoId", codigoEquipo);
                            cmd.Parameters.AddWithValue("@UsuarioId", codigoUsuario);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al agregar usuario al equipo: " + ex.Message);
                    }
                }
            }
        }

    }
}