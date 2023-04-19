using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoHotel.Logica
{
    public class VentaLogica
    {
        private static VentaLogica instancia = null;

        public VentaLogica()
        {

        }

        public static VentaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new VentaLogica();
                }

                return instancia;
            }
        }

        public List<Venta> Listar()
        {
            List<Venta> Lista = new List<Venta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select IdVenta,IdRecepcion,Total,Estado from venta", oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oRecepcion = new Recepcion() { IdRecepcion = Convert.ToInt32(dr["IdRecepcion"]) },
                                Total = Convert.ToDecimal(dr["Total"].ToString()),
                                Estado = dr["Estado"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Venta>();
                }
            }
            return Lista;
        }

        public bool Registrar(Venta objeto)
        {
            bool respuesta = true;
            
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    oConexion.Open();

                    SqlTransaction objTransacion = oConexion.BeginTransaction();


                    sb.AppendLine("declare @idventa int = 0");
                    sb.AppendLine(string.Format("insert into VENTA(IdRecepcion,Total,Estado) values ({0},{1},'{2}')", objeto.oRecepcion.IdRecepcion,objeto.Total,objeto.Estado));
                    sb.AppendLine("set @idventa = SCOPE_IDENTITY()");
                    foreach (DetalleVenta dv in objeto.oDetalleVenta)
                    {
                        sb.AppendLine(string.Format("insert into DETALLE_VENTA(IdVenta,IdProducto,Cantidad,SubTotal) values({0},{1},{2},{3})", "@idventa", dv.oProducto.IdProducto, dv.Cantidad, dv.SubTotal));

                        sb.AppendLine(string.Format("update producto set Cantidad = Cantidad - {0} where IdProducto = {1}", dv.Cantidad, dv.oProducto.IdProducto));
                    }
                    sb.AppendLine("select @idventa");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = objTransacion;
                    try
                    {
                        int idventa = 0;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out idventa);

                        if (idventa != 0)
                        {
                            objTransacion.Commit();
                            respuesta = true;
                        }
                        else
                        {
                            objTransacion.Rollback();
                            respuesta = false;
                        }

                    }
                    catch (Exception e)
                    {
                        objTransacion.Rollback();
                        respuesta = false;
                    }

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