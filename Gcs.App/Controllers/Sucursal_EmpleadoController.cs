using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class Sucursal_EmpleadoController : Controller
    {
        private readonly DataSucursal_Empleado dataSucursal_Empleado = new DataSucursal_Empleado();
        // GET: Sucursal_Empleado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear_Sucursal_Empleado()
        {
            return View();
        }
        public ActionResult Editar_Sucursal_Empleado()
        {
            return View();
        }

        public JsonResult CrearSucursalEmpleado(string IdUser, int IdSucursal, int IdEmpleado, string FechaInicial, string FechaFinal)
        {
            string resultado = dataSucursal_Empleado.CrearSucursalEmpleado(IdUser, IdSucursal, IdEmpleado, FechaInicial, FechaFinal);
            return Json(resultado);
        }

        public ActionResult GridSucursalEmpleado()
        {
            var data = dataSucursal_Empleado.GridSucursalEmpleado();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GuardarCambiosSucursal_Empleado(int IdSucursalEmpleado, int IdSucursal_Empleado, string IdUser, string NombreSucursal_Empleado, int Activo)
        //{
        //    var resultado = dataSucursal_Empleado.GuardarCambiosSucursal_Empleado(IdPais, IdSucursal_Empleado, IdUser, NombreSucursal_Empleado, Activo);
        //    return Json(resultado);
        //}
        //public JsonResult EliminarSucursal_Empleado(string IdUser, int IdSucursal_Empleado)
        //{
        //    string resultado = dataSucursal_Empleado.EliminarSucursal_Empleado(IdUser, IdSucursal_Empleado);
        //    return Json(resultado);
        //}
    }
}