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
            List<Barometro> listaBarometro = new List<Barometro>();
            listaBarometro = (List<Barometro>)Session["barometro"];
            listaBarometro.Add(barometro1);
            Session["barometro"] = listaBarometro;                
                
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
            List<SensorGas> sensorGas = new List<SensorGas>();
            sensorGas = (List<SensorGas>)Session["sensorGas"];
            sensorGas.Add(sensorGas1);
            Session["sensorGas"] = sensorGas;   
            
            return View();
        }

    }
    
}