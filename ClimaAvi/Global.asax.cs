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
            //Executado sempre que uma sess�o da aplica��o � iniciada

            // Inicia a lista de Usu�rios /////////////////////////////////////////////////////////////////////////

            User user1 = new User()
            {
                Codigo = 1,
                Name = "Evandro",
                Email = "evandro@gmail.com",
                LastName = "Machado",
                Password = "1111",
            };

            User user2 = new User()
            {
                Codigo = 1,
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
                MacHost = "2CC",
           };

            List<Planta> listPlanta = new List<Planta>();           
            listPlanta.Add(planta2);
            Session["planta"] = listPlanta;

            // Inicia a lista dos dados do Barometro //////////////////////////////////////////////////////////////

            Barometro barometro = new Barometro()
            {
                Altitude = 200,
                Temperatura = 23,
                PressaoAtmosferica = 1020,
                UmidadeAr = 20,
                MacHostBarometro = "2CC",
        };
            List<Barometro> listaBarometro = new List<Barometro>();
            listaBarometro.Add(barometro);
            Session["barometro"] = listaBarometro;

            // Inicia a lista dos dados do Sensor Gas //////////////////////////////////////////////////////////////

            SensorGas sensorGas = new SensorGas()
            {
                Metano = 3,
                Propeno = 4,
                Hidrogenio = 78,
                Fumaca = 1,
                MachostGas = "2CC",
        };
            List<SensorGas> listaSensorGas = new List<SensorGas>();            
            listaSensorGas.Add(sensorGas);
            Session["sensorGas"] = listaSensorGas;

        }

    }
}

