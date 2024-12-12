using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatInsumo
    {
        public List<EntInsumo> Listar(int codigoSprint)
        {
            List<EntInsumo> lista = new List<EntInsumo>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerInsumosPorCodigoSprint", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@codigoSprint", codigoSprint);
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EntInsumo dato = new EntInsumo
                                {
                                    codigo = reader.GetInt32(reader.GetOrdinal("codigo")),
                                    nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? null : reader.GetString(reader.GetOrdinal("nombre")),
                                    descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                                    cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                                    objSprint = new EntSprint
                                    {
                                        codigo = reader.GetInt32(reader.GetOrdinal("codigoSprint")),
                                        nombre = reader.IsDBNull(reader.GetOrdinal("nombreSprint")) ? null : reader.GetString(reader.GetOrdinal("nombreSprint")),
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
        public List<EntInsumo> ObtenerPorCodigo(int codigo)
        {
            List<EntInsumo> lista = new List<EntInsumo>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerInsumosPorCodigoInsumo", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@codigoInsumo", codigo);
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EntInsumo dato = new EntInsumo
                                {
                                    codigo = reader.GetInt32(reader.GetOrdinal("codigo")),
                                    nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? null : reader.GetString(reader.GetOrdinal("nombre")),
                                    descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString(reader.GetOrdinal("descripcion")),
                                    cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                                    objSprint = new EntSprint
                                    {
                                        codigo = reader.GetInt32(reader.GetOrdinal("codigoSprint")),
                                        nombre = reader.IsDBNull(reader.GetOrdinal("nombreSprint")) ? null : reader.GetString(reader.GetOrdinal("nombreSprint")),
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

        public bool registrar(EntInsumo obj)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    SqlCommand comando = new SqlCommand("SP_RegistrarInsumoWeb", conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@nombre", obj.nombre);
                    comando.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    comando.Parameters.AddWithValue("@cantidad", obj.cantidad);
                    comando.Parameters.AddWithValue("@codigoSprint", obj.objSprint.codigo);

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

        public bool editar(EntInsumo obj)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    SqlCommand comando = new SqlCommand("SP_ActualizarInsumoWeb", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("codigo", obj.codigo);
                    comando.Parameters.AddWithValue("@nombre", obj.nombre);
                    comando.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    comando.Parameters.AddWithValue("@cantidad", obj.cantidad);

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
                    using (SqlCommand command = new SqlCommand("SP_EliminarInsumo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@codigo", codigo);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el insumo.", ex);
                }
            }
        }
    }
}
