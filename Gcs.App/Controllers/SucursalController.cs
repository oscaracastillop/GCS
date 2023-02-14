using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class SucursalController : Controller
    {
        private readonly DataSucursal dataSucursal = new DataSucursal();
        // GET: Sucursal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Sucursal()
        {
            return View();
        }
        public ActionResult Editar_Sucursal()
        {
            return View();
        }
        public JsonResult CrearSucursal(string IdUser, int IdEmpresa,string NombreSucursal, int IdTipoDocumento, string Identificacion, string Email, string Telefono, string Contacto, int IdCiudad, string Direccion)
        {
            string resultado = dataSucursal.CrearSucursal(IdUser, IdEmpresa, NombreSucursal, IdTipoDocumento, Identificacion, Email, Telefono, Contacto, IdCiudad, Direccion);
            return Json(resultado);
        }
        public JsonResult GuardarCambiosSucursal(int IdSucursal, int IdEmpresa, string IdUser, string NombreSucursal, int IdTipoDocumento, string Identificacion, string Email, string Telefono, string Contacto, int IdCiudad, string Direccion, int Activo)
        {
            var resultado = dataSucursal.GuardarCambiosSucursal(IdSucursal, IdEmpresa, IdUser, NombreSucursal, IdTipoDocumento, Identificacion, Email, Telefono, Contacto, IdCiudad, Direccion, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarSucursal(string IdUser, int IdSucursal)
        {
            string resultado = dataSucursal.EliminarSucursal(IdUser, IdSucursal);
            return Json(resultado);
        }

        public ActionResult CargarDatosSucursal(int IdSucursal)
        {
            var resultado = dataSucursal.CargarDatosSucursal(IdSucursal);
            return Json(resultado);
        }
        public JsonResult ListaSucursal()
        {
            var resultado = dataSucursal.ListaSucursal();
            return Json(resultado);
        }
        public ActionResult GridSucursal()
        {
            var data = dataSucursal.GridSucursal();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}