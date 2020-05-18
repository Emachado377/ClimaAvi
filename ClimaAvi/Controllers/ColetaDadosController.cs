using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class ColetaDadosController : Controller
    {
        // GET: ColetaDados
        public ActionResult DadosBarometro()
        {
            List<Barometro> listaBarometro = new List<Barometro>();
            listaBarometro = (List<Barometro>)Session["barometro"];
            var barometro = listaBarometro.OrderByDescending(c => c.LeituraBarometro).Take(1);
            return Json(barometro);
        }

        public ActionResult DadosGas()
        {
            // Essa função buscará na API essas informações
            SensorGas sensorGas1 = new SensorGas()
            {
                Metano = 3,
                Propeno = 4,
                Hidrogenio = 78,
                Fumaca = 1,
            };
            List<SensorGas> sensorGas = new List<SensorGas>();
            sensorGas = (List<SensorGas>)Session["sensorGas"];
            sensorGas.Add(sensorGas1);
            Session["sensorGas"] = sensorGas;   
            
            return View();
        }

    }
    
}