using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoGeneroController : Controller
    {
        private readonly DataTipoGenero dataTipoGenero = new DataTipoGenero();
        // GET: TipoGenero
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoGenero()
        {
            return View();
        }
        public ActionResult Editar_TipoGenero()
        {
            return View();
        }
        public JsonResult CrearTipoGenero(string IdUser, string NombreTipoGenero)
        {
            string resultado = dataTipoGenero.CrearTipoGenero(IdUser, NombreTipoGenero);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoGenero(int IdTipoGenero, string IdUser, string NombreTipoGenero, int Activo)
        {
            var resultado = dataTipoGenero.GuardarCambiosTipoGenero(IdTipoGenero, IdUser, NombreTipoGenero, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoGenero(string IdUser, int IdTipoGenero)
        {
            string resultado = dataTipoGenero.EliminarTipoGenero(IdUser, IdTipoGenero);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoGenero(int IdTipoGenero)
        {
            var resultado = dataTipoGenero.CargarDatosTipoGenero(IdTipoGenero);
            return Json(resultado);
        }

        public JsonResult ListaTipoGenero()
        {
            var resultado = dataTipoGenero.ListaTipoGenero();
            return Json(resultado);
        }
        public ActionResult GridTipoGenero()
        {
            var data = dataTipoGenero.GridTipoGenero();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}