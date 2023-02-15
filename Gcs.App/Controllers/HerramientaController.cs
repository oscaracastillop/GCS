using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class HerramientaController : Controller
    {
        // GET: Herramienta
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Herramienta()
        {
            return View();
        }
        public ActionResult Editar_Herramienta()
        {
            return View();
        }
    }
}