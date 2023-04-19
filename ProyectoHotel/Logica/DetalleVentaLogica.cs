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
    public class DetalleVentaLogica
    {
        private static DetalleVentaLogica instancia = null;

        public DetalleVentaLogica()
        {

        }

        public static DetalleVentaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DetalleVentaLogica();
                }

                return instancia;
            }
        }

        public List<DetalleVenta> Listar()
        {
            List<DetalleVenta> Lista = new List<DetalleVenta>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine(" select dv.IdDetalleVenta,dv.IdVenta,p.IdProducto,p.Nombre,p.Precio,dv.Cantidad,dv.SubTotal from detalle_venta dv");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dv.IdProducto");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new DetalleVenta()
                            {
                                IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"]),
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                oProducto = new Producto() {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"].ToString()),
                                },
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString())
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<DetalleVenta>();
                }
            }
            return Lista;
        }
    }
}