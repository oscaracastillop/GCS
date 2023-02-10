using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class EpsController : Controller
    {
        private readonly DataEps dataEps = new DataEps();
        // GET: Eps
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Eps()
        {
            return View();
        }
        public ActionResult Editar_Eps()
        {
            return View();
        }
        public JsonResult CrearEps(string IdUser, string NombreEps)
        {
            string resultado = dataEps.CrearEps(IdUser, NombreEps);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosEps(int IdEps, string IdUser, string NombreEps, int Activo)
        {
            var resultado = dataEps.GuardarCambiosEps(IdEps, IdUser, NombreEps, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarEps(string IdUser, int IdEps)
        {
            string resultado = dataEps.EliminarEps(IdUser, IdEps);
            return Json(resultado);
        }

        public ActionResult CargarDatosEps(int IdEps)
        {
            var resultado = dataEps.CargarDatosEps(IdEps);
            return Json(resultado);
        }

        public JsonResult ListaEps()
        {
            var resultado = dataEps.ListaEps();
            return Json(resultado);
        }
        public ActionResult GridEps()
        {
            var data = dataEps.GridEps();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}