using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DataEmpleado dataEmpleado = new DataEmpleado();
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Empleado()
        {
            return View();
        }
        public ActionResult Editar_Empleado()
        {
            return View();
        }
        public ActionResult Hoja_Vida_Empleado()
        {
            return View();
        }

        public JsonResult CrearEmpleado(string IdUser, string NombreEmpleado, string ApellidoEmpleado, int IdTipoDocumento, string Identificacion)
        {
            string resultado = dataEmpleado.CrearEmpleado(IdUser, NombreEmpleado, ApellidoEmpleado, IdTipoDocumento, Identificacion);
            return Json(resultado);
        }
        public ActionResult CargarDatosHVEmpleado(int IdEmpleado)
        {
            var resultado = dataEmpleado.CargarDatosHVEmpleado(IdEmpleado);
            return Json(resultado);
        }

        public ActionResult CargarDatosPersonales(int IdEmpleado)
        {
            var resultado = dataEmpleado.CargarDatosPersonales(IdEmpleado);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosDatosPersonales(int IdEmpleado, string IdUser, int IdNacionalidad, string FechaNacimientoEmpleado, string LugarNacimientoEmpleado, int IdSexoEmpleado, int IdTipoEstadoCivil, string EmailEmpleado, string Telefono1Empleado, string Telefono2Empleado)
        {
            var resultado = dataEmpleado.GuardarCambiosDatosPersonales(IdEmpleado, IdUser, IdNacionalidad, FechaNacimientoEmpleado, LugarNacimientoEmpleado, IdSexoEmpleado, IdTipoEstadoCivil, EmailEmpleado, Telefono1Empleado, Telefono2Empleado);
            return Json(resultado);
        }

        public ActionResult GridEmpleado()
        {
            var data = dataEmpleado.GridEmpleado();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}