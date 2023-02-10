using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class FondoCesantiasController : Controller
    {
        private readonly DataFondoCesantias dataFondoCesantias = new DataFondoCesantias();
        // GET: FondoCesantias
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_FondoCesantias()
        {
            return View();
        }
        public ActionResult Editar_FondoCesantias()
        {
            return View();
        }
        public JsonResult CrearFondoCesantias(string IdUser, string NombreFondoCesantias, string Email, string Telefono)
        {
            string resultado = dataFondoCesantias.CrearFondoCesantias(IdUser, NombreFondoCesantias, Email, Telefono);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosFondoCesantias(int IdFondoCesantias, string IdUser, string NombreFondoCesantias, string Email, string Telefono, int Activo)
        {
            var resultado = dataFondoCesantias.GuardarCambiosFondoCesantias(IdFondoCesantias, IdUser, NombreFondoCesantias, Email, Telefono, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarFondoCesantias(string IdUser, int IdFondoCesantias)
        {
            string resultado = dataFondoCesantias.EliminarFondoCesantias(IdUser, IdFondoCesantias);
            return Json(resultado);
        }

        public ActionResult CargarDatosFondoCesantias(int IdFondoCesantias)
        {
            var resultado = dataFondoCesantias.CargarDatosFondoCesantias(IdFondoCesantias);
            return Json(resultado);
        }

        public JsonResult ListaFondoCesantias()
        {
            var resultado = dataFondoCesantias.ListaFondoCesantias();
            return Json(resultado);
        }
        public ActionResult GridFondoCesantias()
        {
            var data = dataFondoCesantias.GridFondoCesantias();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}