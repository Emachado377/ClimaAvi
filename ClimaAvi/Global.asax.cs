using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            User user1 = new User()
            {
                Code = 1,
                Name = "Evandro",
                Email = "eeeeeeee@hotmail.com",
                Phone = "5498888888888",
                Password = "1",
            };

            User user2 = new User()
            {
                Code = 1,
                Name = "Ruan",
                Email = "rrrrr@hotmail.com",
                Phone = "5498888888888",
                Password = "2",
            };

            List<User> listUser = new List<User>();
            listUser.Add(user1);
            listUser.Add(user2);
            
            Session["users"] = listUser;
        }
    }
}
