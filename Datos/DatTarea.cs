using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatTarea
    {
        public bool Registrar(EntTarea tarea)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_RegistrarTareaWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", tarea.sNombre ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Descripcion", tarea.sDescripcion ?? string.Empty);
                    cmd.Parameters.AddWithValue("@FechaInicio", tarea.dtFechaInicio);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", tarea.dtFechaVencimiento);
                    cmd.Parameters.AddWithValue("@Prioridad", tarea.iPrioridad);
                    cmd.Parameters.AddWithValue("@CodigoUsuario", tarea.eUsuario.iCodigo);
                    cmd.Parameters.AddWithValue("@CodigoActividad", tarea.eActividad.iCodigo);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Actualizar(EntTarea tarea)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarTareaWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", tarea.iCodigo);
                    cmd.Parameters.AddWithValue("@Nombre", tarea.sNombre);
                    cmd.Parameters.AddWithValue("@Descripcion", tarea.sDescripcion);
                    cmd.Parameters.AddWithValue("@FechaActualizacion", tarea.dtFechaActualizacion);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", tarea.dtFechaVencimiento);
                    cmd.Parameters.AddWithValue("@Prioridad", tarea.iPrioridad);
                    cmd.Parameters.AddWithValue("@Progreso", tarea.iProgreso);
                    cmd.Parameters.AddWithValue("@CodigoUsuario", tarea.eUsuario.iCodigo);
                    cmd.Parameters.AddWithValue("@CodigoEstado", tarea.eEstado.iCodigo);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public EntTarea ObtenerPorCodigo(int codigo)
        {
            EntTarea tarea = null;
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerTareaPorCodigoWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tarea = new EntTarea
                            {
                                iCodigo = Convert.ToInt32(reader["codigo"]),
                                sNombre = reader["nombre"].ToString(),
                                sDescripcion = reader["descripcion"]?.ToString(),
                                dtFechaInicio = reader["fechaInicio"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["fechaInicio"]) : DateTime.Now,
                                dtFechaActualizacion = reader["fechaActualizacion"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["fechaActualizacion"]) : DateTime.Now,
                                dtFechaVencimiento = reader["fechaVencimiento"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["fechaVencimiento"]) : DateTime.Now,
                                iPrioridad = Convert.ToInt32(reader["prioridad"]),
                                iProgreso = Convert.ToInt32(reader["progreso"]),
                                eUsuario = new EntUsuario
                                {
                                    iCodigo = Convert.ToInt32(reader["codigoUsuario"]),
                                    sNombres = reader["nombreUsuario"].ToString()
                                },
                                eEstado = new EntEstado
                                {
                                    iCodigo = Convert.ToInt32(reader["codigoEstado"]),
                                    sNombre = reader["nombreEstado"].ToString()
                                },
                                eActividad = new EntActividad
                                {
                                    iCodigo = Convert.ToInt32(reader["codigoActividad"])
                                }
                            };
                        }
                    }
                }
            }
            return tarea;
        }

        public List<EntTarea> ListarPorActividad(int codigoActividad)
        {
            List<EntTarea> lista = new List<EntTarea>();
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarTareasPorActividadWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoActividad", codigoActividad);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EntTarea
                            {
                                iCodigo = Convert.ToInt32(reader["codigo"]),
                                sNombre = reader["nombre"].ToString(),
                                sDescripcion = reader["descripcion"]?.ToString(),
                                dtFechaInicio = reader["fechaInicio"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["fechaInicio"]) : DateTime.Now,
                                dtFechaActualizacion = reader["fechaActualizacion"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["fechaActualizacion"]) : DateTime.Now,
                                dtFechaVencimiento = reader["fechaVencimiento"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["fechaVencimiento"]) : DateTime.Now,
                                iPrioridad = Convert.ToInt32(reader["prioridad"]),
                                iProgreso = Convert.ToInt32(reader["progreso"]),
                                eUsuario = new EntUsuario
                                {
                                    iCodigo = Convert.ToInt32(reader["codigoUsuario"]),
                                    sNombres = reader["nombreUsuario"].ToString()
                                },
                                eEstado = new EntEstado
                                {
                                    iCodigo = Convert.ToInt32(reader["codigoEstado"]),
                                    sNombre = reader["nombreEstado"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public bool Eliminar(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EliminarTareaWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}