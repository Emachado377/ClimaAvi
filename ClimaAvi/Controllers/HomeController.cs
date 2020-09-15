using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClimaAvi.Models;

namespace ClimaAvi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //List<Planta> listPlanta;
            APIHttpClient client = new APIHttpClient("http://localhost:52198/api/");
            var listPlanta = client.Get<List<Planta>>("planta");
            ViewBag.listPlanta = listPlanta;

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