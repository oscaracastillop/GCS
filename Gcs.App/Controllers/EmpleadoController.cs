using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class EmpleadoController : Controller
    {
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
    }
}