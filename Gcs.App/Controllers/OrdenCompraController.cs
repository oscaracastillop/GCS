using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class OrdenCompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_OrdenCompra()
        {
            return View();
        }
        public ActionResult Editar_OrdenCompra()
        {
            return View();
        }
    }
}