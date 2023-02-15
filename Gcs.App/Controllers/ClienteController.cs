using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Cliente()
        {
            return View();
        }
        public ActionResult Editar_Cliente()
        {
            return View();
        }
    }
}