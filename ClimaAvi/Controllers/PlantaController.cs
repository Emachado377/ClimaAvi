using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class PlantaController : Controller
    {
        // GET: Planta
        public ActionResult Index()
        {
            List<Planta> listPlanta = new List<Planta>();
            listPlanta = (List<Planta>)Session["planta"];
            ViewBag.listPlanta = listPlanta;
            return View(listPlanta);
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
                return View("Adicionar", planta);

            }
            else
            {
                List<Planta> listaPlanta = new List<Planta>();
                listaPlanta = (List<Planta>)Session["planta"];
                foreach (var busca in listaPlanta)
                {
                    if ((String.Equals(busca.CodigoPlanta, planta.CodigoPlanta) || (String.Equals(busca.NomePlanta, planta.NomePlanta))))
                    {
                        ModelState.AddModelError("planta.ok", "NOME OU CODIGO JÁ EXISTE!");
                       
                        return View("Adicionar", planta);
                    }
                }
                listaPlanta.Add(planta);
                Session["planta"] = listaPlanta;

                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Alterar(Guid Id)
        {
            Planta planta = null;
            if (Session["planta"] != null)
            {
                var itens = (List<Models.Planta>)Session["planta"];
                planta = itens.Where(c => c.Id == Id).FirstOrDefault();
                itens.Remove(planta);
            }
            return View("Adicionar", planta);
        }  
        
        public ActionResult Excluir(Guid Id)
        {
            Planta planta = null;
            if (Session["planta"] != null)
            {
                var itens = (List<Models.Planta>)Session["planta"];
                planta = itens.Where(c => c.Id == Id).FirstOrDefault();
                itens.Remove(planta);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
