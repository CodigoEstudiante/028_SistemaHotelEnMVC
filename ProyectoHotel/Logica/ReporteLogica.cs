using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoHotel.Logica
{
    public class ReporteLogica
    {

        private static ReporteLogica instancia = null;

        public ReporteLogica()
        {

        }

        public static ReporteLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ReporteLogica();
                }

                return instancia;
            }
        }

        public DataTable Productos(string estado,string fechainicio,string fechafin) {

            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SET DATEFORMAT dmy;");
                    sb.AppendLine("select Nombre, Detalle, Precio, Cantidad, iif(Estado = 1, 'Activo', 'No Activo')[Estado],CONVERT(char(10),FechaCreacion,103)[Fecha Creacion] from producto");
                    sb.AppendLine("where estado = iif(@estado = 2, estado, @estado) and convert(date,FechaCreacion) between @fechainicio and @fechafin");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                }
                catch (Exception ex)
                {
                    dt = new DataTable();
                }

            }
            return dt;

        }

        public DataTable Recepciones(string idhabitacion, string fechainicio, string fechafin)
        {

            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SET DATEFORMAT dmy;");
                    sb.AppendLine("select h.Numero[Numero Habitacion],h.Detalle[Detalle Habitacion] ,c.Descripcion[Categoria Habitacion],");
                    sb.AppendLine("(p.Nombre + ' ' + p.Apellido)[Cliente],p.Correo[Correo Cliente],");
                    sb.AppendLine("CONVERT(char(10), r.FechaEntrada, 103)[Fecha Entrada],CONVERT(char(10), r.FechaSalida, 103)[Fecha Salida],CONVERT(char(10), r.FechaSalidaConfirmacion, 103)[Fecha Salida Confirmacion],");
                    sb.AppendLine("r.PrecioInicial[Precio Inicial],r.Adelanto,r.CostoPenalidad[Costo Penalidad],r.TotalPagado[Total Pagado]");
                    sb.AppendLine("from RECEPCION r");
                    sb.AppendLine("inner join HABITACION h on h.IdHabitacion = r.IdHabitacion");
                    sb.AppendLine("inner join CATEGORIA c on c.IdCategoria = h.IdCategoria");
                    sb.AppendLine("inner join PERSONA p on p.IdPersona = r.IdCliente");
                    sb.AppendLine("where convert(date, r.FechaEntrada) between @fechainicio and @fechafin");
                    sb.AppendLine("and h.IdHabitacion = iif(@idhabitacion = 0, h.IdHabitacion,@idhabitacion)");
                    
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idhabitacion", idhabitacion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                }
                catch (Exception ex)
                {
                    dt = new DataTable();
                }

            }
            return dt;

        }

    }
}