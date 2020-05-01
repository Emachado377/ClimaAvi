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
            Planta planta = new Planta();

            return View(planta);
        }

        [HttpPost]
        public ActionResult Gravar(Planta planta)
        {
            if (ModelState.IsValid == false)
            {
                return View("Adicionar", planta );

            }
            List<Planta> listPlanta = new List<Planta>();
            listPlanta = (List<Planta>) Session["planta"];

            listPlanta.Add(planta);

            return RedirectToAction("Index", "Home");
        }
    }
}