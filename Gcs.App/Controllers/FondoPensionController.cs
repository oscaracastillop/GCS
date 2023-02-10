using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class FondoPensionController : Controller
    {
        private readonly DataFondoPension dataFondoPension = new DataFondoPension();
        // GET: FondoPension
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_FondoPension()
        {
            return View();
        }
        public ActionResult Editar_FondoPension()
        {
            return View();
        }
        public JsonResult CrearFondoPension(string IdUser, string NombreFondoPension, string Email, string Telefono)
        {
            string resultado = dataFondoPension.CrearFondoPension(IdUser, NombreFondoPension, Email, Telefono);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosFondoPension(int IdFondoPension, string IdUser, string NombreFondoPension, string Email, string Telefono, int Activo)
        {
            var resultado = dataFondoPension.GuardarCambiosFondoPension(IdFondoPension, IdUser, NombreFondoPension, Email, Telefono, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarFondoPension(string IdUser, int IdFondoPension)
        {
            string resultado = dataFondoPension.EliminarFondoPension(IdUser, IdFondoPension);
            return Json(resultado);
        }

        public ActionResult CargarDatosFondoPension(int IdFondoPension)
        {
            var resultado = dataFondoPension.CargarDatosFondoPension(IdFondoPension);
            return Json(resultado);
        }

        public JsonResult ListaFondoPension()
        {
            var resultado = dataFondoPension.ListaFondoPension();
            return Json(resultado);
        }
        public ActionResult GridFondoPension()
        {
            var data = dataFondoPension.GridFondoPension();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}