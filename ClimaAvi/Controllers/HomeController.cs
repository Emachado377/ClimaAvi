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
            List<Planta> listPlanta;
            // listPlanta = (List<Planta>)Session["planta"];

            APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
            listPlanta = client.Get<List<Planta>>("planta");

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