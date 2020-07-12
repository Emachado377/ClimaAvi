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
            APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
            listPlanta = client.Get<List<Planta>>("Planta");
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
                APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
                var plantas = client.Get<List<Planta>>("Planta");

                foreach (var busca in plantas)
                {
                    if ((String.Equals(busca.CodigoPlanta, planta.CodigoPlanta) || (String.Equals(busca.NomePlanta, planta.NomePlanta))))
                    {
                        ModelState.AddModelError("planta.ok", "NOME OU CODIGO JÁ EXISTE!");

                        return View("Adicionar", planta);
                    }
                }
                var id = client.Post<Planta>("planta", planta);

                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Alterar(Guid Id)// Editar
        {
            List<Planta> plantas;
            Planta plt = null;           
            APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
            plantas = client.Get<List<Planta>>("Planta/");

           foreach (var busca in plantas)
            {
                if (busca.Id == Id)
                {                           
                  plt = busca;
                }
            }
            return View("Adicionar", plt);
        }  
        
        public ActionResult Excluir(Guid Id)
        {           
            APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
            client.Delete<List<Planta>>("Planta/", Id);
                       
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Abrir(Guid Id)
        {
            Planta planta = null;

            APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
            planta = client.Get<Planta>("Planta/"+Id);

            return View("Dashboard", planta);

        }
    }
}
