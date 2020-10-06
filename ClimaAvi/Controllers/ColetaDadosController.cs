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
        public ActionResult DadosBarometro(String mach)
        {
            List<Barometro> barometros = new List<Barometro>();
            APIHttpClient client = new APIHttpClient("http://localhost:52198/api/");
           var listaBarometro = client.Get<List<Barometro>>("barometro");

            foreach (var busca in listaBarometro)
            {
                busca.MacHostBarometro = mach;
                barometros.Add(busca);
            }
            return View("Dashbord",listaBarometro);
        }

        public ActionResult DadosGas(String mach)
        {
            List<SensorGas> listaGas = new List<SensorGas>();
            APIHttpClient client = new APIHttpClient("http://localhost:52198/api/");
            var sensorGas = client.Get<List<SensorGas>>("SensorGas");
            foreach (var busca in listaGas)
            {
                busca.MachostGas = mach;
                listaGas.Add(busca);
            }
            return View("Dashbord", listaGas);
        }

    }
    
}