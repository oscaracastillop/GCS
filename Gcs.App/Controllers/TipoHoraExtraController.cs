using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoHoraExtraController : Controller
    {
        private readonly DataTipoHoraExtra dataTipoHoraExtra = new DataTipoHoraExtra();
        // GET: TipoHoraExtra
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoHoraExtra()
        {
            return View();
        }
        public ActionResult Editar_TipoHoraExtra()
        {
            return View();
        }
        public JsonResult CrearTipoHoraExtra(string IdUser, string NombreTipoHoraExtra)
        {
            string resultado = dataTipoHoraExtra.CrearTipoHoraExtra(IdUser, NombreTipoHoraExtra);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoHoraExtra(int IdTipoHoraExtra, string IdUser, string NombreTipoHoraExtra, int Activo)
        {
            var resultado = dataTipoHoraExtra.GuardarCambiosTipoHoraExtra(IdTipoHoraExtra, IdUser, NombreTipoHoraExtra, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoHoraExtra(string IdUser, int IdTipoHoraExtra)
        {
            string resultado = dataTipoHoraExtra.EliminarTipoHoraExtra(IdUser, IdTipoHoraExtra);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoHoraExtra(int IdTipoHoraExtra)
        {
            var resultado = dataTipoHoraExtra.CargarDatosTipoHoraExtra(IdTipoHoraExtra);
            return Json(resultado);
        }

        public JsonResult ListaTipoHoraExtra()
        {
            var resultado = dataTipoHoraExtra.ListaTipoHoraExtra();
            return Json(resultado);
        }
        public ActionResult GridTipoHoraExtra()
        {
            var data = dataTipoHoraExtra.GridTipoHoraExtra();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}