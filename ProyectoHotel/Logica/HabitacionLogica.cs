using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoHotel.Logica
{
    public class HabitacionLogica
    {
        private static HabitacionLogica instancia = null;

        public HabitacionLogica()
        {

        }

        public static HabitacionLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new HabitacionLogica();
                }

                return instancia;
            }
        }

        public bool Registrar(Habitacion oHabitacion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarHabitacion", oConexion);
                    cmd.Parameters.AddWithValue("Numero", oHabitacion.Numero);
                    cmd.Parameters.AddWithValue("Detalle", oHabitacion.Detalle);
                    cmd.Parameters.AddWithValue("Precio", Convert.ToDecimal(oHabitacion.PrecioTexto,new CultureInfo("es-PE")));
                    cmd.Parameters.AddWithValue("IdPiso", oHabitacion.oPiso.IdPiso);
                    cmd.Parameters.AddWithValue("IdCategoria", oHabitacion.oCategoria.IdCategoria);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool Modificar(Habitacion oHabitacion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarHabitacion", oConexion);
                    cmd.Parameters.AddWithValue("IdHabitacion", oHabitacion.IdHabitacion);
                    cmd.Parameters.AddWithValue("Numero", oHabitacion.Numero);
                    cmd.Parameters.AddWithValue("Detalle", oHabitacion.Detalle);
                    cmd.Parameters.AddWithValue("Precio", Convert.ToDecimal(oHabitacion.PrecioTexto, new CultureInfo("es-PE")));
                    cmd.Parameters.AddWithValue("IdPiso", oHabitacion.oPiso.IdPiso);
                    cmd.Parameters.AddWithValue("IdCategoria", oHabitacion.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", oHabitacion.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }


        public List<Habitacion> Listar()
        {
            List<Habitacion> Lista = new List<Habitacion>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select h.IdHabitacion,h.Numero,h.Detalle,h.Precio,p.IdPiso,p.Descripcion[DescripcionPiso],c.IdCategoria,c.Descripcion[DescripcionCategoria],h.Estado,");
                    query.AppendLine("eh.IdEstadoHabitacion,eh.Descripcion[DescripcionEstadoHabitacion]");
                    query.AppendLine("from habitacion h");
                    query.AppendLine("inner join PISO p on p.IdPiso = h.IdPiso");
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = h.IdCategoria");
                    query.AppendLine("inner join ESTADO_HABITACION eh on eh.IdEstadoHabitacion = h.IdEstadoHabitacion");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Habitacion()
                            {
                                IdHabitacion = Convert.ToInt32(dr["IdHabitacion"]),
                                Numero = dr["Numero"].ToString(),
                                Detalle = dr["Detalle"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"].ToString()),
                                oPiso = new Piso() { IdPiso = Convert.ToInt32(dr["IdPiso"]), Descripcion = dr["DescripcionPiso"].ToString() },
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                oEstadoHabitacion = new EstadoHabitacion() { IdEstadoHabitacion = Convert.ToInt32(dr["IdEstadoHabitacion"]) , Descripcion = dr["DescripcionEstadoHabitacion"].ToString() },
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Habitacion>();
                }
            }
            return Lista;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Habitacion where idHabitacion = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public bool ActualizarEstado(int idhabitacion, int idestadohabitacion)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update HABITACION set idestadohabitacion = @idestadohabitacion where IdHabitacion = @idhabitacion ", oConexion);
                    cmd.Parameters.AddWithValue("@idhabitacion", idhabitacion);
                    cmd.Parameters.AddWithValue("@idestadohabitacion", idestadohabitacion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = true;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}