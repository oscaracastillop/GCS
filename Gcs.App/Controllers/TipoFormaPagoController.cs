using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoFormaPagoController : Controller
    {
        private readonly DataTipoFormaPago dataTipoFormaPago = new DataTipoFormaPago();
        // GET: TipoFormaPago
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoFormaPago()
        {
            return View();
        }
        public ActionResult Editar_TipoFormaPago()
        {
            return View();
        }
        public JsonResult CrearTipoFormaPago(string IdUser, string NombreTipoFormaPago)
        {
            string resultado = dataTipoFormaPago.CrearTipoFormaPago(IdUser, NombreTipoFormaPago);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoFormaPago(int IdTipoFormaPago, string IdUser, string NombreTipoFormaPago, int Activo)
        {
            var resultado = dataTipoFormaPago.GuardarCambiosTipoFormaPago(IdTipoFormaPago, IdUser, NombreTipoFormaPago, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoFormaPago(string IdUser, int IdTipoFormaPago)
        {
            string resultado = dataTipoFormaPago.EliminarTipoFormaPago(IdUser, IdTipoFormaPago);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoFormaPago(int IdTipoFormaPago)
        {
            var resultado = dataTipoFormaPago.CargarDatosTipoFormaPago(IdTipoFormaPago);
            return Json(resultado);
        }

        public JsonResult ListaTipoFormaPago()
        {
            var resultado = dataTipoFormaPago.ListaTipoFormaPago();
            return Json(resultado);
        }
        public ActionResult GridTipoFormaPago()
        {
            var data = dataTipoFormaPago.GridTipoFormaPago();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}