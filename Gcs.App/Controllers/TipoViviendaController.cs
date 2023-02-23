using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class TipoViviendaController : Controller
    {
        private readonly DataTipoVivienda dataTipoVivienda = new DataTipoVivienda();
        // GET: TipoVivienda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_TipoVivienda()
        {
            return View();
        }
        public ActionResult Editar_TipoVivienda()
        {
            return View();
        }
        public JsonResult CrearTipoVivienda(string IdUser, string NombreTipoVivienda)
        {
            string resultado = dataTipoVivienda.CrearTipoVivienda(IdUser, NombreTipoVivienda);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosTipoVivienda(int IdTipoVivienda, string IdUser, string NombreTipoVivienda, int Activo)
        {
            var resultado = dataTipoVivienda.GuardarCambiosTipoVivienda(IdTipoVivienda, IdUser, NombreTipoVivienda, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarTipoVivienda(string IdUser, int IdTipoVivienda)
        {
            string resultado = dataTipoVivienda.EliminarTipoVivienda(IdUser, IdTipoVivienda);
            return Json(resultado);
        }

        public ActionResult CargarDatosTipoVivienda(int IdTipoVivienda)
        {
            var resultado = dataTipoVivienda.CargarDatosTipoVivienda(IdTipoVivienda);
            return Json(resultado);
        }

        public JsonResult ListaTipoVivienda()
        {
            var resultado = dataTipoVivienda.ListaTipoVivienda();
            return Json(resultado);
        }
        public ActionResult GridTipoVivienda()
        {
            var data = dataTipoVivienda.GridTipoVivienda();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}