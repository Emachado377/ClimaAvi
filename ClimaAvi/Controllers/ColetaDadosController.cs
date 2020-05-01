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
            // Essa função buscará na API essas informações
            Barometro barometro1 = new Barometro()
            {
                Altitude = 200,
                Temperatura = 23,
                PressaoAtmosferica = 1020,
                UmidadeAr = 20,

            };
            List<Planta> planta1 = new List<Planta>();

            planta1 = (List<Planta>)Session["planta"];
            planta1.Add(barometro1);
            Session["planta"] = planta1;                
                
            return View("DadosGas");
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
            List<Planta> planta1 = new List<Planta>();

            planta1 = (List<Planta>)Session["planta"];
            planta1.Add(sensorGas1);
            Session["planta"] = planta1;   
            
            return View();
        }

    }
    
}