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
            // Inicia a lista de Usuários /////////////////////////////////////////////////////////////////////////

            // Inicia a lista dos dados da Planta ///////////////////////////////////////////////////////////

            Planta planta2 = new Planta()
            {
                CodigoPlanta = 10,
                NomePlanta = "Aviario 1",
                LocalPlanta = "Fazenda Souza",
                MacHost = "2CC",
            };

            List<Planta> plantas = new List<Planta>();
            plantas.Add(planta2);
            Session["planta"] = plantas;

        }
    }
}
