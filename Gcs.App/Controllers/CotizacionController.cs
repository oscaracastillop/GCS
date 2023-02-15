using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Cotizacion()
        {
            return View();
        }
        public ActionResult Editar_Cotizacion()
        {
            return View();
        }
    }
}