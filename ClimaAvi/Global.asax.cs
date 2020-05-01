using ClimaAvi.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClimaAvi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
                Password = "1",
            };

            User user2 = new User()
            {
                Code = 1,
                Name = "Ruan",
                Email = "ruan@gmail.com",
                LastName = "Ferreira",
                Password = "2",
            };

            List<User> listUser = new List<User>();
            listUser.Add(user1);
            listUser.Add(user2);
            
            Session["users"] = listUser;


            // Inicia a lista dos dados da Planta ///////////////////////////////////////////////////////////

           Planta planta2 = new Planta()
            {
                CodigoPlanta = 100,
                NomePlanta = "Aviario 1",
                LocalPlanta = "Fazenda Souza",
            };


            Barometro barometro2 = new Barometro()
            {
                Altitude = 200,
                Temperatura = 23,
                PressaoAtmosferica = 1020,
                UmidadeAr = 20,

            };
            
            SensorGas sensorGas2 = new SensorGas()
            {
                Metano = 3,
                Propeno = 4,
                Hidrogenio = 78,
                Fumaca = 1,
            };

            List<Planta> listPlanta = new List<Planta>();
            listPlanta.Add(barometro2);
            listPlanta.Add(sensorGas2);
            listPlanta.Add(planta2);

            Session["planta"] = listPlanta;

        }

    }
}

