using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear_Categoria()
        {
            return View();
        }
        public ActionResult Editar_Categoria()
        {
            return View();
        }
    }
}