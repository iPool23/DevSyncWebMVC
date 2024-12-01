using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatProyecto
    {
        public List<EntProyecto> Listar()
        {
            List<EntProyecto> lista = new List<EntProyecto>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DatConexion.sCadena))
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerProyectosUsuarioLiderProyecto", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EntProyecto proyecto = new EntProyecto
                                {
                                    iCodigo = reader.GetInt32(reader.GetOrdinal("codigo")),
                                    sNombre = reader.IsDBNull(reader.GetOrdinal("Proyecto")) ? null : reader.GetString(reader.GetOrdinal("Proyecto")),
                                    sImgUrl = reader.IsDBNull(reader.GetOrdinal("imgUrl")) ? null : reader.GetString(reader.GetOrdinal("imgUrl")),
                                    sDescripcion = null, // No devuelto por el SP, se deja como null
                                    iProgreso = 0, // Valor predeterminado, ya que no se incluye en el SP
                                    dtFechaInicio = DateTime.MinValue, // No devuelto por el SP
                                    dtFechaFin = DateTime.MinValue, // No devuelto por el SP
                                };

                                lista.Add(proyecto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de Datos: Listar Proyectos: " + ex.Message);
            }

            return lista;
        }
    }
}
