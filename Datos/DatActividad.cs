using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatActividad
    {
        public List<EntActividad> ListarPorSprint(int codigoSprint)
        {
            List<EntActividad> lista = new List<EntActividad>();
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarActividadesPorSprintWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoSprint", codigoSprint);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var actividad = new EntActividad
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombre = reader["nombre"].ToString(),
                                sDescripcion = reader["descripcion"].ToString(),
                                iProgreso = (int)reader["progreso"],
                                eTipoActividad = new EntTipoActividad
                                {
                                    iCodigo = (int)reader["codigoTipoActividad"],
                                    sNombre = reader["nombreTipoActividad"].ToString()
                                },
                                eEstado = new EntEstado
                                {
                                    iCodigo = (int)reader["codigoEstado"],
                                    sNombre = reader["nombreEstado"].ToString()
                                }
                            };
                            lista.Add(actividad);
                        }
                    }
                }
            }
            return lista;
        }

        public bool Registrar(EntActividad actividad)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_RegistrarActividadWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", actividad.sNombre);
                    cmd.Parameters.AddWithValue("@Descripcion", actividad.sDescripcion);
                    cmd.Parameters.AddWithValue("@Progreso", actividad.iProgreso);
                    cmd.Parameters.AddWithValue("@CodigoTipoActividad", actividad.eTipoActividad.iCodigo);
                    cmd.Parameters.AddWithValue("@CodigoSprint", actividad.eSprint.codigo);
                    cmd.Parameters.AddWithValue("@CodigoEstado", actividad.eEstado.iCodigo);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Actualizar(EntActividad actividad)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarActividadWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", actividad.iCodigo);
                    cmd.Parameters.AddWithValue("@Nombre", actividad.sNombre);
                    cmd.Parameters.AddWithValue("@Descripcion", actividad.sDescripcion);
                    cmd.Parameters.AddWithValue("@Progreso", actividad.iProgreso);
                    cmd.Parameters.AddWithValue("@CodigoTipoActividad", actividad.eTipoActividad.iCodigo);
                    cmd.Parameters.AddWithValue("@CodigoEstado", actividad.eEstado.iCodigo);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public EntActividad ObtenerPorCodigo(int codigo)
        {
            EntActividad actividad = null;
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerActividadPorCodigoWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            actividad = new EntActividad
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombre = reader["nombre"].ToString(),
                                sDescripcion = reader["descripcion"].ToString(),
                                iProgreso = (int)reader["progreso"],
                                eTipoActividad = new EntTipoActividad
                                {
                                    iCodigo = (int)reader["codigoTipoActividad"],
                                    sNombre = reader["nombreTipoActividad"].ToString()
                                },
                                eEstado = new EntEstado
                                {
                                    iCodigo = (int)reader["codigoEstado"],
                                    sNombre = reader["nombreEstado"].ToString()
                                },
                                eSprint = new EntSprint
                                {
                                    codigo = (int)reader["codigoSprint"]
                                }
                            };
                        }
                    }
                }
            }
            return actividad;
        }

        public bool Eliminar(int codigo)
        {
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EliminarActividadWeb", conn))
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