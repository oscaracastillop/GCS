using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoUnidadMedidaController : Controller
    {
        // GET: TipoUnidadMedida
        private readonly DataTipoUnidadMedida dataTipoUnidadMedida = new DataTipoUnidadMedida();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoUnidadMedida()
        {
            return View();
        }
        public ActionResult Editar_TipoUnidadMedida()
        {
            return View();
        }
        public JsonResult CrearTipoUnidadMedida(string IdUser, string NombreTipoUnidadMedida)
        {
            string resultado = dataTipoUnidadMedida.CrearTipoUnidadMedida(IdUser, NombreTipoUnidadMedida);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoUnidadMedida(int IdTipoUnidadMedida, string IdUser, string NombreTipoUnidadMedida, int Activo)
        {
            var resultado = dataTipoUnidadMedida.GuardarCambiosTipoUnidadMedida(IdTipoUnidadMedida, IdUser, NombreTipoUnidadMedida, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoUnidadMedida(string IdUser, int IdTipoUnidadMedida)
        {
            string resultado = dataTipoUnidadMedida.EliminarTipoUnidadMedida(IdUser, IdTipoUnidadMedida);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoUnidadMedida(int IdTipoUnidadMedida)
        {
            var resultado = dataTipoUnidadMedida.CargarDatosTipoUnidadMedida(IdTipoUnidadMedida);
            return Json(resultado);
        }

        public JsonResult ListaTipoUnidadMedida()
        {
            var resultado = dataTipoUnidadMedida.ListaTipoUnidadMedida();
            return Json(resultado);
        }
        public ActionResult GridTipoUnidadMedida()
        {
            var data = dataTipoUnidadMedida.GridTipoUnidadMedida();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}