using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class ArlController : Controller
    {
        private readonly DataArl dataArl = new DataArl();
        // GET: Arl
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Arl()
        {
            return View();
        }
        public ActionResult Editar_Arl()
        {
            return View();
        }
        public JsonResult CrearArl(string IdUser, string NombreArl)
        {
            string resultado = dataArl.CrearArl(IdUser, NombreArl);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosArl(int IdArl, string IdUser, string NombreArl, int Activo)
        {
            var resultado = dataArl.GuardarCambiosArl(IdArl, IdUser, NombreArl, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarArl(string IdUser, int IdArl)
        {
            string resultado = dataArl.EliminarArl(IdUser, IdArl);
            return Json(resultado);
        }

        public ActionResult CargarDatosArl(int IdArl)
        {
            var resultado = dataArl.CargarDatosArl(IdArl);
            return Json(resultado);
        }

        public JsonResult ListaArl()
        {
            var resultado = dataArl.ListaArl();
            return Json(resultado);
        }
        public ActionResult GridArl()
        {
            var data = dataArl.GridArl();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}