using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class PaisController : Controller
    {
        private readonly DataPais dataPais = new DataPais();
        // GET: Pais
        #region Vistas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Pais()
        {
            return View();
        }
        public ActionResult Editar_Pais()
        {
            return View();
        }
        #endregion

        #region Metodos
        public JsonResult CrearPais(string IdUser, string NombrePais)
        {
            string resultado = dataPais.CrearPais(IdUser, NombrePais);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosPais(int IdPais, string IdUser, string NombrePais, int Activo)
        {
            var resultado = dataPais.GuardarCambiosPais(IdPais, IdUser, NombrePais, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarPais(string IdUser, int IdPais)
        {
            string resultado = dataPais.EliminarPais(IdUser, IdPais);
            return Json(resultado);
        }

        public ActionResult CargarDatosPais(int IdPais)
        {
            var resultado = dataPais.CargarDatosPais(IdPais);
            return Json(resultado);
        }

        public JsonResult ListaPais()
        {
            var resultado = dataPais.ListaPais();
            return Json(resultado);
        }
        public ActionResult GridPais()
        {
            var data = dataPais.GridPais();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
