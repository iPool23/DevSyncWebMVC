using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DatSprint
    {
        public List<EntSprint> Listar(int codigoProyecto)
        {
            List<EntSprint> lista = new List<EntSprint>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerSprintsWeb", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@codigoProyecto", codigoProyecto);
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EntSprint dato = new EntSprint
                                {
                                    codigo = reader.GetInt32(reader.GetOrdinal("codigo")),
                                    nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? null : reader.GetString(reader.GetOrdinal("nombre")),
                                    progreso = reader.GetInt32(reader.GetOrdinal("progreso")),
                                    fechaInicio = reader.GetDateTime(reader.GetOrdinal("fechaInicio")),
                                    fechaFin = reader.GetDateTime(reader.GetOrdinal("fechaFin")),
                                    objUsuario = new EntUsuario
                                    {
                                        iCodigo = reader.GetInt32(reader.GetOrdinal("codigoLider")),
                                        sNombres = reader.IsDBNull(reader.GetOrdinal("lider")) ? null : reader.GetString(reader.GetOrdinal("lider")),
                                    },
                                    objProyecto = new EntProyecto
                                    {
                                        iCodigo = reader.GetInt32(reader.GetOrdinal("codigoProyecto")),
                                        sNombre = reader.IsDBNull(reader.GetOrdinal("proyecto")) ? null : reader.GetString(reader.GetOrdinal("proyecto")),
                                    }
                                };
                                lista.Add(dato);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de Datos: " + ex.Message);
            }
            return lista;
        }

        public List<EntSprint> ObtenerPorCodigo(int codigoSprint)
        {
            List<EntSprint> lista = new List<EntSprint>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerSprintPorCodigoWeb", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@CodigoSprint", codigoSprint);
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EntSprint dato = new EntSprint
                                {
                                    codigo = reader.GetInt32(reader.GetOrdinal("codigo")),
                                    nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? null : reader.GetString(reader.GetOrdinal("nombre")),
                                    progreso = reader.GetInt32(reader.GetOrdinal("progreso")),
                                    fechaInicio = reader.GetDateTime(reader.GetOrdinal("fechaInicio")),
                                    fechaFin = reader.GetDateTime(reader.GetOrdinal("fechaFin")),
                                    objUsuario = new EntUsuario
                                    {
                                        iCodigo = reader.GetInt32(reader.GetOrdinal("codigoLider")),
                                        sNombres = reader.IsDBNull(reader.GetOrdinal("lider")) ? null : reader.GetString(reader.GetOrdinal("lider")),
                                    },
                                    objProyecto = new EntProyecto
                                    {
                                        iCodigo = reader.GetInt32(reader.GetOrdinal("codigoProyecto")),
                                        sNombre = reader.IsDBNull(reader.GetOrdinal("proyecto")) ? null : reader.GetString(reader.GetOrdinal("proyecto")),
                                    }
                                };
                                lista.Add(dato);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de Datos: " + ex.Message);
            }
            return lista;
        }

        public bool registrar(EntSprint obj)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    SqlCommand comando = new SqlCommand("SP_CrearSprintWeb", conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@nombre", obj.nombre);
                    comando.Parameters.AddWithValue("@progreso", obj.progreso);
                    comando.Parameters.AddWithValue("@fechaInicio", obj.fechaInicio);
                    comando.Parameters.AddWithValue("@fechaFin", obj.fechaFin);
                    comando.Parameters.AddWithValue("@codigoLider", obj.objUsuario.iCodigo);
                    comando.Parameters.AddWithValue("@codigoProyecto", obj.objProyecto.iCodigo);

                    // Abrir conexión
                    conexion.Open();

                    // Ejecutar comando
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Verificar si se insertó al menos una fila
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de Datos: " + ex.Message);
            }
        }

        public bool editar(EntSprint obj)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    SqlCommand comando = new SqlCommand("SP_ActualizarSprintWeb", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("codigo", obj.codigo);
                    comando.Parameters.AddWithValue("nombre", obj.nombre);
                    comando.Parameters.AddWithValue("progreso", obj.progreso);
                    comando.Parameters.AddWithValue("fechaInicio", obj.fechaInicio);
                    comando.Parameters.AddWithValue("fechaFin", obj.fechaFin);
                    comando.Parameters.AddWithValue("codigoLider", obj.objUsuario.iCodigo);
                    comando.Parameters.AddWithValue("codigoProyecto", obj.objProyecto.iCodigo);

                    // Abrir conexión
                    conexion.Open();

                    // Ejecutar comando
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Verificar si se insertó al menos una fila
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de Datos: " + ex.Message);
            }
        }
        public bool Eliminar(int codigo)
        {
            using (SqlConnection connection = new SqlConnection(DatConexion.sCadena))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SP_EliminarSprint", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codigo", codigo);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el sprint.", ex);
                }
            }
        }

    }
}
