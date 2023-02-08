using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly DataDepartamento dataDepartamento = new DataDepartamento();
        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Departamento()
        {
            return View();
        }
        public ActionResult Editar_Departamento()
        {
            return View();
        }

        public JsonResult CrearDepartamento(string IdUser, int IdPais, string NombreDepartamento)
        {
            string resultado = dataDepartamento.CrearDepartamento(IdUser, IdPais, NombreDepartamento);
            return Json(resultado);
        }

        public JsonResult GuardarCambiosDepartamento(int IdPais, int IdDepartamento, string IdUser, string NombreDepartamento, int Activo)
        {
            var resultado = dataDepartamento.GuardarCambiosDepartamento(IdPais, IdDepartamento, IdUser, NombreDepartamento, Activo);
            return Json(resultado);
        }
        public JsonResult EliminarDepartamento(string IdUser, int IdDepartamento)
        {
            string resultado = dataDepartamento.EliminarDepartamento(IdUser, IdDepartamento);
            return Json(resultado);
        }

        public ActionResult CargarDatosDepartamento(int IdDepartamento)
        {
            var resultado = dataDepartamento.CargarDatosDepartamento(IdDepartamento);
            return Json(resultado);
        }

        public JsonResult ListaDepartamento()
        {
            var resultado = dataDepartamento.ListaDepartamento();
            return Json(resultado);
        }
        public ActionResult GridDepartamento()
        {
            var data = dataDepartamento.GridDepartamento();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}