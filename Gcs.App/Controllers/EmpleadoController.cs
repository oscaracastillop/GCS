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

        public ActionResult CargarDatosCabeceraEmpleado(int IdEmpleado)
        {
            var resultado = dataEmpleado.CargarDatosCabeceraEmpleado(IdEmpleado);
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

        public ActionResult CargarDatosResidencia(int IdEmpleado)
        {
            var resultado = dataEmpleado.CargarDatosResidencia(IdEmpleado);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosDatosResidencia(int IdEmpleado, string IdUser, int IdCiudad, string DireccionEmpleado, int IdTipoVivienda, string NombreArrendador, string TelefonoArrendador, string TiempoResidiendo)
        {
            var resultado = dataEmpleado.GuardarCambiosDatosResidencia(IdEmpleado, IdUser, IdCiudad, DireccionEmpleado,IdTipoVivienda, NombreArrendador, TelefonoArrendador, TiempoResidiendo);
            return Json(resultado);
        }

        public ActionResult CargarDatosRFEmpleado(int IdEmpleado)
        {
            var resultado = dataEmpleado.CargarDatosRFEmpleado(IdEmpleado);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosRFEmpleado(int IdEmpleado, string IdUser, string NombreRF1Empleado, string ParentescoRF1Empleado, string TelefonoRF1Empleado, string ProfesionRF1Empleado, string NombreRF2Empleado, string ParentescoRF2Empleado, string TelefonoRF2Empleado, string ProfesionRF2Empleado)
        {
            var resultado = dataEmpleado.GuardarCambiosRFEmpleado(IdEmpleado, IdUser, NombreRF1Empleado, ParentescoRF1Empleado, TelefonoRF1Empleado, ProfesionRF1Empleado, NombreRF2Empleado, ParentescoRF2Empleado, TelefonoRF2Empleado, ProfesionRF2Empleado);
            return Json(resultado);
        }

        public ActionResult CargarDatosRPEmpleado(int IdEmpleado)
        {
            var resultado = dataEmpleado.CargarDatosRPEmpleado(IdEmpleado);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosRPEmpleado(int IdEmpleado, string IdUser, string NombreRP1Empleado, string DireccionRP1Empleado, string TelefonoRP1Empleado, string ProfesionRP1Empleado, string NombreRP2Empleado, string DireccionRP2Empleado, string TelefonoRP2Empleado, string ProfesionRP2Empleado)
        {
            var resultado = dataEmpleado.GuardarCambiosRPEmpleado(IdEmpleado, IdUser, NombreRP1Empleado, DireccionRP1Empleado, TelefonoRP1Empleado, ProfesionRP1Empleado, NombreRP2Empleado, DireccionRP2Empleado, TelefonoRP2Empleado, ProfesionRP2Empleado);
            return Json(resultado);
        }

        public JsonResult ListaEmpleado()
        {
            var resultado = dataEmpleado.ListaEmpleado();
            return Json(resultado);
        }
      
        public ActionResult GridEmpleado()
        {
            var data = dataEmpleado.GridEmpleado();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}