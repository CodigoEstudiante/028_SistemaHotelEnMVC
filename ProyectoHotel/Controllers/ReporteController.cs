using ClosedXML.Excel;
using ProyectoHotel.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoHotel.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Productos()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        public ActionResult Recepciones()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpPost]
        public FileResult ExportarProductos(string estado,string fechainicio, string fechafin)
        {

            DataTable dt = ReporteLogica.Instancia.Productos(estado,fechainicio,fechafin);

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte Productos " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }

        [HttpPost]
        public FileResult ExportarRecepciones(string idhabitacion, string fechainicio, string fechafin)
        {

            DataTable dt = ReporteLogica.Instancia.Recepciones(idhabitacion, fechainicio, fechafin);

            dt.TableName = "Datos";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte Recepciones " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }
    }
}