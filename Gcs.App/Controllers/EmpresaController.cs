using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly DataEmpresa dataEmpresa = new DataEmpresa();
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Empresa()
        {
            return View();
        }
        public ActionResult Editar_Empresa()
        {
            return View();
        }
        public JsonResult CrearEmpresa(string IdUser, string NombreEmpresa, int IdTipoDocumento, string Identificacion, string Email, string Telefono, string Contacto, int IdCiudad, string Direccion)
        {
            string resultado = dataEmpresa.CrearEmpresa(IdUser, NombreEmpresa, IdTipoDocumento, Identificacion, Email, Telefono, Contacto, IdCiudad, Direccion);
            return Json(resultado);
        }

        //public JsonResult GuardarCambiosEmpresa(int IdEmpresa, string IdUser, string NombreEmpresa, int Activo)
        //{
        //    var resultado = dataEmpresa.GuardarCambiosEmpresa(IdEmpresa, IdUser, NombreEmpresa, Activo);
        //    return Json(resultado);
        //}
        //public JsonResult EliminarEmpresa(string IdUser, int IdEmpresa)
        //{
        //    string resultado = dataEmpresa.EliminarEmpresa(IdUser, IdEmpresa);
        //    return Json(resultado);
        //}

        //public ActionResult CargarDatosEmpresa(int IdEmpresa)
        //{
        //    var resultado = dataEmpresa.CargarDatosEmpresa(IdEmpresa);
        //    return Json(resultado);
        //}

        //public JsonResult ListaEmpresa()
        //{
        //    var resultado = dataEmpresa.ListaEmpresa();
        //    return Json(resultado);
        //}
        public ActionResult GridEmpresa()
        {
            var data = dataEmpresa.GridEmpresa();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}