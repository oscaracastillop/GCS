using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class MaquinariaController : Controller
    {
        // GET: Maquinaria
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Maquinaria()
        {
            return View();
        }
        public ActionResult Editar_Maquinaria()
        {
            return View();
        }
    }
}