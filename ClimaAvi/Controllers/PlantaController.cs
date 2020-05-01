using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class PlantaController : Controller
    {
        // GET: Planta
        public ActionResult Index()
        {
            List<Planta> listPlanta;
            listPlanta = (List<Planta>) Session["planta"]; 
            ViewBag.listPlanta = listPlanta;

            return View();
        }
        public ActionResult Adicionar()
        {
            List<Planta> listPlanta;


            return View();
        }
    }
}