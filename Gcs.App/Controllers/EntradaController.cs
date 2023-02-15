using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class EntradaController : Controller
    {
        // GET: Entrada
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Entrada()
        {
            return View();
        }
        public ActionResult Editar_Entrada()
        {
            return View();
        }
    }
}