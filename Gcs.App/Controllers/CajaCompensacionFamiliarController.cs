using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class CajaCompensacionFamiliarController : Controller
    {
        private readonly DataCajaCompensacionFamiliar dataCajaCompensacionFamiliar = new DataCajaCompensacionFamiliar();
        // GET: CajaCompensacionFamiliar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_CajaCompensacionFamiliar()
        {
            return View();
        }
        public ActionResult Editar_CajaCompensacionFamiliar()
        {
            return View();
        }
        public JsonResult CrearCajaCompensacionFamiliar(string IdUser, string NombreCajaCompensacionFamiliar, string Email, string Telefono)
        {
            string resultado = dataCajaCompensacionFamiliar.CrearCajaCompensacionFamiliar(IdUser, NombreCajaCompensacionFamiliar, Email, Telefono);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosCajaCompensacionFamiliar(int IdCajaCompensacionFamiliar, string IdUser, string NombreCajaCompensacionFamiliar, string Email, string Telefono, int Activo)
        {
            var resultado = dataCajaCompensacionFamiliar.GuardarCambiosCajaCompensacionFamiliar(IdCajaCompensacionFamiliar, IdUser, NombreCajaCompensacionFamiliar,Email, Telefono, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarCajaCompensacionFamiliar(string IdUser, int IdCajaCompensacionFamiliar)
        {
            string resultado = dataCajaCompensacionFamiliar.EliminarCajaCompensacionFamiliar(IdUser, IdCajaCompensacionFamiliar);
            return Json(resultado);
        }

        public ActionResult CargarDatosCajaCompensacionFamiliar(int IdCajaCompensacionFamiliar)
        {
            var resultado = dataCajaCompensacionFamiliar.CargarDatosCajaCompensacionFamiliar(IdCajaCompensacionFamiliar);
            return Json(resultado);
        }

        public JsonResult ListaCajaCompensacionFamiliar()
        {
            var resultado = dataCajaCompensacionFamiliar.ListaCajaCompensacionFamiliar();
            return Json(resultado);
        }
        public ActionResult GridCajaCompensacionFamiliar()
        {
            var data = dataCajaCompensacionFamiliar.GridCajaCompensacionFamiliar();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}