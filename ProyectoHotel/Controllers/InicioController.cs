using ProyectoHotel.Logica;
using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoHotel.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        // GET: Inicio
        public ActionResult Usuario()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        // GET: Inicio
        public ActionResult Cliente()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpGet]
        public JsonResult ListarTipoPersona()
        {
            List<TipoPersona> oLista = new List<TipoPersona>();
            oLista = PersonaLogica.Instancia.ListarTipoPersona();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarPersona()
        {
            List<Persona> oLista = new List<Persona>();

            oLista = PersonaLogica.Instancia.Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarPersona(Persona objeto)
        {
            bool respuesta = false;
            objeto.Clave = objeto.Clave == null ? "" : objeto.Clave;
            objeto.TipoDocumento = objeto.TipoDocumento == null ? "" : objeto.TipoDocumento;
            respuesta = (objeto.IdPersona == 0) ? PersonaLogica.Instancia.Registrar(objeto) : PersonaLogica.Instancia.Modificar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarPersona(int id)
        {
            bool respuesta = false;
            respuesta = PersonaLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}