using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class MenuController : Controller
    {
        private readonly DataMenu dataMenu = new DataMenu();

        public JsonResult ListaMenu(string Usuario)
        {
            var resultado = dataMenu.ListaMenu(Usuario);
            return Json(resultado);
        }
    }
}