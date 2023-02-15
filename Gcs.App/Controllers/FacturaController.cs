using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Factura()
        {
            return View();
        }
        public ActionResult Editar_Factura()
        {
            return View();
        }
    }
}