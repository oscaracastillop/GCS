using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class CiudadController : Controller
    {
        private readonly DataCiudad dataCiudad = new DataCiudad();
        // GET: Ciudad
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Ciudad()
        {
            return View();
        }
        public ActionResult Editar_Ciudad()
        {
            return View();
        }
        
        public JsonResult CrearCiudad(string IdUser, int IdDepartamento, string NombreCiudad)
        {
            string resultado = dataCiudad.CrearCiudad(IdUser, IdDepartamento, NombreCiudad);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosCiudad(int IdDepartamento, int IdCiudad, string IdUser, string NombreCiudad, int Activo)
        {
            var resultado = dataCiudad.GuardarCambiosCiudad(IdDepartamento, IdCiudad, IdUser, NombreCiudad, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarCiudad(string IdUser, int IdCiudad)
        {
            string resultado = dataCiudad.EliminarCiudad(IdUser, IdCiudad);
            return Json(resultado);
        }

        public ActionResult CargarDatosCiudad(int IdCiudad)
        {
            var resultado = dataCiudad.CargarDatosCiudad(IdCiudad);
            return Json(resultado);
        }

        public JsonResult ListaCiudad()
        {
            var resultado = dataCiudad.ListaCiudad();
            return Json(resultado);
        }
        public JsonResult BuscarCiudadIdDepto(int IdDepartamento)
        {
            var resultado = dataCiudad.BuscarCiudadIdDepto(IdDepartamento);
            return Json(resultado);
        }
        public ActionResult GridCiudad()
        {
            var data = dataCiudad.GridCiudad();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}