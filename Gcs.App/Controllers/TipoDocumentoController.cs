using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly DataTipoDocumento dataTipoDocumento = new DataTipoDocumento();
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoDocumento()
        {
            return View();
        }
        public ActionResult Editar_TipoDocumento()
        {
            return View();
        }
        public JsonResult CrearTipoDocumento(string IdUser, string NombreTipoDocumento)
        {
            string resultado = dataTipoDocumento.CrearTipoDocumento(IdUser, NombreTipoDocumento);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoDocumento(int IdTipoDocumento, string IdUser, string NombreTipoDocumento, int Activo)
        {
            var resultado = dataTipoDocumento.GuardarCambiosTipoDocumento(IdTipoDocumento, IdUser, NombreTipoDocumento, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoDocumento(string IdUser, int IdTipoDocumento)
        {
            string resultado = dataTipoDocumento.EliminarTipoDocumento(IdUser, IdTipoDocumento);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoDocumento(int IdTipoDocumento)
        {
            var resultado = dataTipoDocumento.CargarDatosTipoDocumento(IdTipoDocumento);
            return Json(resultado);
        }

        public JsonResult ListaTipoDocumento()
        {
            var resultado = dataTipoDocumento.ListaTipoDocumento();
            return Json(resultado);
        }
        public ActionResult GridTipoDocumento()
        {
            var data = dataTipoDocumento.GridTipoDocumento();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}