using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoEstadoCivilController : Controller
    {
        private readonly DataTipoEstadoCivil dataTipoEstadoCivil = new DataTipoEstadoCivil();
        // GET: TipoEstadoCivil
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoEstadoCivil()
        {
            return View();
        }
        public ActionResult Editar_TipoEstadoCivil()
        {
            return View();
        }
        public JsonResult CrearTipoEstadoCivil(string IdUser, string NombreTipoEstadoCivil)
        {
            string resultado = dataTipoEstadoCivil.CrearTipoEstadoCivil(IdUser, NombreTipoEstadoCivil);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoEstadoCivil(int IdTipoEstadoCivil, string IdUser, string NombreTipoEstadoCivil, int Activo)
        {
            var resultado = dataTipoEstadoCivil.GuardarCambiosTipoEstadoCivil(IdTipoEstadoCivil, IdUser, NombreTipoEstadoCivil, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoEstadoCivil(string IdUser, int IdTipoEstadoCivil)
        {
            string resultado = dataTipoEstadoCivil.EliminarTipoEstadoCivil(IdUser, IdTipoEstadoCivil);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoEstadoCivil(int IdTipoEstadoCivil)
        {
            var resultado = dataTipoEstadoCivil.CargarDatosTipoEstadoCivil(IdTipoEstadoCivil);
            return Json(resultado);
        }

        public JsonResult ListaTipoEstadoCivil()
        {
            var resultado = dataTipoEstadoCivil.ListaTipoEstadoCivil();
            return Json(resultado);
        }
        public ActionResult GridTipoEstadoCivil()
        {
            var data = dataTipoEstadoCivil.GridTipoEstadoCivil();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}