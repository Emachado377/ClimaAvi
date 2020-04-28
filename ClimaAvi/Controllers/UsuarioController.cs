using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ClimaAvi.Controllers
{
    public class UsuarioController : Controller
    {

        List<User> userTemp = new List<User>(); // declarando a lista temporaria para login

        // GET: Usuario
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
           return View();
        }

        public ActionResult Register()
        {
           return View();
        }

        public ActionResult ForgotPassord()
        {
            return View();
        }
    }
}