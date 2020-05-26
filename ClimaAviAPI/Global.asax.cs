using ClimaAvi.Models;
using ClimaAviAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClimaAviAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            //Executado sempre que uma sessão da aplicação é iniciada

            // Inicia a lista de Usuários /////////////////////////////////////////////////////////////////////////

            User user1 = new User()
            {
                Code = 1,
                Name = "Evandro",
                Email = "evandro@gmail.com",
                LastName = "Machado",
                Password = "1111",
            };

            User user2 = new User()
            {
                Code = 2,
                Name = "Ruan",
                Email = "ruan@gmail.com",
                LastName = "Ferreira",
                Password = "2222",
            };

            List<User> listUser = new List<User>();
            listUser.Add(user1);
            listUser.Add(user2);

            Session["users"] = listUser;


            // Inicia a lista dos dados da Planta ///////////////////////////////////////////////////////////

            Planta planta2 = new Planta()
            {
                CodigoPlanta = 10,
                NomePlanta = "Aviario 1",
                LocalPlanta = "Fazenda Souza",
            };

            List<Planta> listPlanta = new List<Planta>();
            listPlanta.Add(planta2);
            Session["planta"] = listPlanta;

            // Inicia a lista dos dados do Barometro //////////////////////////////////////////////////////////////

           

            // Inicia a lista dos dados do Sensor Gas //////////////////////////////////////////////////////////////

            SensorGas sensorGas = new SensorGas()
            {
                Metano = 3,
                Propeno = 4,
                Hidrogenio = 78,
                Fumaca = 1,
                LeituraGas = DateTime.Now
            };
            List<SensorGas> listaSensorGas = new List<SensorGas>();
            listaSensorGas.Add(sensorGas);
            Session["sensorGas"] = listaSensorGas;

        }


    }
}
