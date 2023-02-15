using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Producto()
        {
            return View();
        }
        public ActionResult Editar_Producto()
        {
            return View();
        }
    }
}