using ProyectoHotel.Logica;
using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoHotel.Controllers
{
    public class TiendaController : Controller
    {
        // GET: Tienda
        public ActionResult Producto()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        public ActionResult Vender()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Producto> oLista = new List<Producto>();
            oLista = ProductoLogica.Instancia.Listar().OrderBy(o => o.Nombre).ToList();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarProducto(Producto objeto)
        {
            bool respuesta = false;
            respuesta = (objeto.IdProducto == 0) ? ProductoLogica.Instancia.Registrar(objeto) : ProductoLogica.Instancia.Modificar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool respuesta = false;
            respuesta = ProductoLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarVenta(Venta objeto)
        {
            bool respuesta = false;
            respuesta = VentaLogica.Instancia.Registrar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}