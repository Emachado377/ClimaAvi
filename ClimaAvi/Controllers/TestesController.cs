using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class TestesController : Controller
    {
        // GET: Testes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarPlanta(Plant planta)
        {
            if (planta.CodigoPlanta != null && planta.LocalPlanta != null && planta.NomePlanta != null)
            {
                return Json(new { status = true, mensagem = "Planta cadastrada" });
            }
            else {
                return Json(new { status = false, mensagem = "Não foi possível cadastradar! Por favor verifique os dados" });
            }
            
        }
    }
}