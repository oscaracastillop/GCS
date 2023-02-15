using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Proveedor()
        {
            return View();
        }
        public ActionResult Editar_Proveedor()
        {
            return View();
        }
    }
}