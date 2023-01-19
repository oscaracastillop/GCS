using Gcs.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcs.App.Controllers
{
    public class SubMenuController : Controller
    {
        private readonly DataSubMenu dataSubMenu = new DataSubMenu();

        public JsonResult ListaSubMenu(string Usuario, string Modulo)
        {
            var resultado = dataSubMenu.ListaSubMenu(Usuario, Modulo);
            return Json(resultado);
        }
    }
}