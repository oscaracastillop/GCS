using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class SalidaController : Controller
    {
        // GET: Salida
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Salida()
        {
            return View();
        }
        public ActionResult Editar_Salida()
        {
            return View();
        }
    }
}