using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sifayco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";
            if (!Request.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return PartialView();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return PartialView();
        }

        [Authorize]
        public ActionResult _Dashboard()
        {
            ViewBag.Message = "Página de dashboard.";

            return PartialView();
        }
    }
}
