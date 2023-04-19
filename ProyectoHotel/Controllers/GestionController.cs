using ProyectoHotel.Logica;
using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoHotel.Controllers
{
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult Recepcion()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        // GET: Gestion
        public ActionResult RecepcionRegistro(int idhabitacion)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            Habitacion objeto = HabitacionLogica.Instancia.Listar().Where(h => h.IdHabitacion == idhabitacion).FirstOrDefault();

            return View(objeto);
        }

        public ActionResult DetalleRecepcion(int idhabitacion)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            Recepcion oRecepcion = RecepcionLogica.Instancia.Listar().Where(h => h.oHabitacion.IdHabitacion == idhabitacion && h.Estado == true).FirstOrDefault();

            if (oRecepcion != null)
            {

                List<Venta> oVenta = (from vn in VentaLogica.Instancia.Listar()
                                      where vn.oRecepcion.IdRecepcion == oRecepcion.IdRecepcion
                                      select new Venta()
                                      {
                                          IdVenta = vn.IdVenta,
                                          oRecepcion = new Recepcion() { IdRecepcion = vn.oRecepcion.IdRecepcion },
                                          Total = vn.Total,
                                          Estado = vn.Estado,
                                          oDetalleVenta = DetalleVentaLogica.Instancia.Listar().Where(dv => dv.IdVenta == vn.IdVenta).ToList()
                                      }).ToList();

                oRecepcion.oVenta = oVenta;
            }

            return View(oRecepcion);
        }

        // GET: Gestion
        public ActionResult Salida()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        // GET: Gestion
        public ActionResult SalidaRegistro(int idhabitacion)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            Recepcion oRecepcion = RecepcionLogica.Instancia.Listar().Where(h => h.oHabitacion.IdHabitacion == idhabitacion && h.Estado == true).FirstOrDefault();

            if (oRecepcion != null) {

                List<Venta> oVenta = (from vn in VentaLogica.Instancia.Listar()
                                      where vn.oRecepcion.IdRecepcion == oRecepcion.IdRecepcion
                                      select new Venta()
                                      {
                                          IdVenta = vn.IdVenta,
                                          oRecepcion = new Recepcion() { IdRecepcion = vn.oRecepcion.IdRecepcion },
                                          Total = vn.Total,
                                          Estado = vn.Estado,
                                          oDetalleVenta = DetalleVentaLogica.Instancia.Listar().Where(dv => dv.IdVenta == vn.IdVenta).ToList()
                                      }).ToList();

                oRecepcion.oVenta = oVenta;
            }

            return View(oRecepcion);
        }

        



        // GET: Gestion
        public ActionResult Venta(int idhabitacion)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            Recepcion objeto = RecepcionLogica.Instancia.Listar().Where(h => h.oHabitacion.IdHabitacion == idhabitacion && h.Estado == true).FirstOrDefault();

            return View(objeto);
        }





        [HttpGet]
        public JsonResult ListarHabitacion(int idpiso)
        {
            List<Habitacion> oLista = new List<Habitacion>();
            oLista = HabitacionLogica.Instancia.Listar().Where(x => x.oPiso.IdPiso == (idpiso == 0 ? x.oPiso.IdPiso : idpiso) ).OrderBy(o => o.Numero).ToList();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ActualizarEstadoHabitacion(int idhabitacion,int idestadohabitacion)
        {

            bool respuesta = false;
            respuesta = HabitacionLogica.Instancia.ActualizarEstado(idhabitacion, idestadohabitacion);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarPersona(Recepcion objeto)
        {
            bool respuesta = false;
            respuesta = RecepcionLogica.Instancia.Registrar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarRecepcion(Recepcion objeto)
        {
            bool respuesta = false;
            objeto.Observacion = objeto.Observacion == null ? "" : objeto.Observacion;
            respuesta = RecepcionLogica.Instancia.Registrar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CerrarRecepcion(Recepcion objeto)
        {
            bool respuesta = false;
            respuesta = RecepcionLogica.Instancia.Cerrar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}