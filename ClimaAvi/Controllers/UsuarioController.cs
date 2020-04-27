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
            ViewBag.usertemporario = userTemp;

            return View();
        }

        public ActionResult Register(User user)
        {
            List<User> users; // declarando a lista
            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado

            users.Add(user); // Adicionamos os dados informados do novo usuario na lista users

            Session["users"] = users;  // atribuimos a lista atualizada de usuários para a sessão, Global.asax

            return View();
        }
        public ActionResult ForgotPassord()
        {
            return View();
        }
    }
}