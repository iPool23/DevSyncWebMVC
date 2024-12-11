using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatProyecto
    {
        public void CrearProyecto(EntProyecto proyecto, string nombreEquipo)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_CrearProyecto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", proyecto.sNombre);
                    command.Parameters.AddWithValue("@Descripcion", proyecto.sDescripcion ?? "");
                    command.Parameters.AddWithValue("@ImgUrl", proyecto.sImgUrl ?? "");
                    command.Parameters.AddWithValue("@CodigoLider", proyecto.eCodigoLider.iCodigo);
                    command.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarProyecto(EntProyecto proyecto)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarProyectoU", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoProyecto", proyecto.iCodigo);
                    command.Parameters.AddWithValue("@Nombre", proyecto.sNombre);
                    command.Parameters.AddWithValue("@Descripcion", proyecto.sDescripcion ?? "");
                    command.Parameters.AddWithValue("@ImgUrl", proyecto.sImgUrl ?? "");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public EntProyecto ObtenerProyectoPorId(int id)
        {
            EntProyecto proyecto = null;
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerProyectoId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoProyecto", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            proyecto = new EntProyecto
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombre = reader["nombre"].ToString(),
                                sDescripcion = reader["descripcion"].ToString(),
                                sImgUrl = reader["imgUrl"].ToString(),
                                eCodigoEquipo = new EntEquipo
                                {
                                    iCodigo = reader["codigoEquipo"] != DBNull.Value ? (int)reader["codigoEquipo"] : 0,
                                    sNombre = reader["nombreEquipo"]?.ToString()
                                }
                            };
                        }
                    }
                }
            }
            return proyecto;
        }

        public List<EntProyecto> ObtenerProyectosPorUsuario(int codigoUsuario)
        {
            List<EntProyecto> proyectos = new List<EntProyecto>();

            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerProyectosPorUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EntProyecto proyecto = new EntProyecto
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombre = (string)reader["nombre"],
                                iProgreso = (int)reader["progreso"],
                                sDescripcion = (string)reader["descripcion"],
                                dtFechaInicio = (DateTime)reader["fechaInicio"],
                                dtFechaFin = (DateTime)reader["fechaFin"],
                                sImgUrl = reader["imgUrl"] as string,
                                eCodigoLider = new EntUsuario
                                {
                                    iCodigo = (int)reader["codigoLider"],
                                    sNombreUsuario = (string)reader["nombreLider"],
                                    sNombres = (string)reader["nombresLider"],
                                    sApellidos = (string)reader["apellidosLider"]
                                },
                                eCodigoEquipo = new EntEquipo
                                {
                                    iCodigo = (int)reader["codigoEquipo"],
                                    sNombre = (string)reader["nombreEquipo"]
                                },
                                eCodigoEstado = new EntEstado
                                {
                                    iCodigo = (int)reader["codigoEstado"],
                                    sNombre = (string)reader["nombreEstado"]
                                }
                            };
                            proyectos.Add(proyecto);
                        }
                    }
                }
            }

            return proyectos;
        }

        public void EliminarProyecto(int id)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Iniciando proceso de eliminación del proyecto " + id);

                    using (SqlCommand command = new SqlCommand("SP_EliminarProyecto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodigoProyecto", id);

                        Console.WriteLine("Ejecutando SP_EliminarProyecto...");
                        command.ExecuteNonQuery();
                        Console.WriteLine("SP_EliminarProyecto ejecutado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar proyecto: " + ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("Finalizando proceso de eliminación");
                }
            }
        }

        public void ActualizarEquipoProyecto(int proyectoId, string nombreEquipo)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_ActualizarEquipoProyecto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoProyecto", proyectoId);
                    command.Parameters.AddWithValue("@NombreEquipo", nombreEquipo);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<EntUsuario> ObtenerUsuariosPorProyecto(int proyectoId)
        {
            List<EntUsuario> usuarios = new List<EntUsuario>();

            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerUsuariosPorProyecto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProyectoId", proyectoId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new EntUsuario
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombreUsuario = reader["nombreUsuario"].ToString(),
                                sCorreo = reader["correo"].ToString(),
                                sNombres = reader["nombres"].ToString(),
                                sApellidos = reader["apellidos"].ToString(),
                                sImgUrl = reader["imgUrl"].ToString(),
                                eCodigoRol = new EntRol
                                {
                                    iCodigo = (int)reader["codigoRol"],
                                    sNombre = reader["nombreRol"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public void AgregarUsuarioAProyecto(int codigoProyecto, int codigoUsuario, int codigoRol)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                try
                {
                    Console.WriteLine($"DAL: Intentando agregar usuario {codigoUsuario} al proyecto {codigoProyecto} con rol {codigoRol}");
                    using (SqlCommand command = new SqlCommand("SP_AgregarUsuarioAProyecto", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodigoProyecto", codigoProyecto);
                        command.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);
                        command.Parameters.AddWithValue("@CodigoRol", codigoRol);

                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("DAL: Usuario agregado exitosamente");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"DAL Error: {ex.Message}");
                    if (ex.Number == 50000) // Número del RAISERROR personalizado
                    {
                        throw new Exception("El usuario ya es miembro del proyecto.");
                    }
                    throw new Exception($"Error al agregar usuario al proyecto: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DAL Error General: {ex.Message}");
                    throw;
                }
            }
        }

        public bool UsuarioEstaEnProyecto(int codigoProyecto, int codigoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                string query = "SELECT COUNT(*) FROM rol_proyecto WHERE codigoProyecto = @CodigoProyecto AND codigoUsuario = @CodigoUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodigoProyecto", codigoProyecto);
                    command.Parameters.AddWithValue("@CodigoUsuario", codigoUsuario);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
