using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class DatTipoActividad
    {
        public List<EntTipoActividad> Listar()
        {
            List<EntTipoActividad> lista = new List<EntTipoActividad>();
            using (SqlConnection conn = new SqlConnection(DatConexion.sCadena))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListarTipoActividadWeb", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipoActividad = new EntTipoActividad
                            {
                                iCodigo = (int)reader["codigo"],
                                sNombre = reader["nombre"].ToString()
                            };
                            lista.Add(tipoActividad);
                        }
                    }
                }
            }
            return lista;
        }
    }
}