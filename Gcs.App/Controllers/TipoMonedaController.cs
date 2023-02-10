using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoMonedaController : Controller
    {
        private readonly DataTipoMoneda dataTipoMoneda = new DataTipoMoneda();
        // GET: TipoMoneda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoMoneda()
        {
            return View();
        }
        public ActionResult Editar_TipoMoneda()
        {
            return View();
        }
        public JsonResult CrearTipoMoneda(string IdUser, string NombreTipoMoneda)
        {
            string resultado = dataTipoMoneda.CrearTipoMoneda(IdUser, NombreTipoMoneda);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoMoneda(int IdTipoMoneda, string IdUser, string NombreTipoMoneda, int Activo)
        {
            var resultado = dataTipoMoneda.GuardarCambiosTipoMoneda(IdTipoMoneda, IdUser, NombreTipoMoneda, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoMoneda(string IdUser, int IdTipoMoneda)
        {
            string resultado = dataTipoMoneda.EliminarTipoMoneda(IdUser, IdTipoMoneda);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoMoneda(int IdTipoMoneda)
        {
            var resultado = dataTipoMoneda.CargarDatosTipoMoneda(IdTipoMoneda);
            return Json(resultado);
        }

        public JsonResult ListaTipoMoneda()
        {
            var resultado = dataTipoMoneda.ListaTipoMoneda();
            return Json(resultado);
        }
        public ActionResult GridTipoMoneda()
        {
            var data = dataTipoMoneda.GridTipoMoneda();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}