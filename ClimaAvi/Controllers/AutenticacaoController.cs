using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        public ActionResult Index()
        {


            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            List<User> users; // declarando a lista
            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado

            ViewBag.users = users;


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

        public ActionResult Validation(User user)
        {
            List<User> users; // declarando a lista
            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado

           
            foreach ( var name in users)
            {
                if ( name.Name == user.Name)
                {
                    if ( name.Password == user.Password)
                    {
                        return RedirectToAction("Index", "Home"); ;
                    }
                }
            }
          return  RedirectToAction("Index"); ;
            
            
        }


    }
}