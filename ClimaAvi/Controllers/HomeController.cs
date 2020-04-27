using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
          HttpCookie cookie = Request.Cookies.Get("Logged");
         
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Dados()
        {      
            return View();
        }

        public ActionResult Criar() 
        {
            return View();
        }

        public ActionResult Error() {
            return View();
        }
    }
}