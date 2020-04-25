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

        List<User> userTemp = new List<User>(); // declarando a lista temporaria para login

        public ActionResult Index()
        {


            return RedirectToAction("Login");
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

        public ActionResult Validation(User userTemp)
        {
            List<User> users; // declarando a lista
            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado


            foreach (var valid in users)
            {
                
                if (String.Equals(valid.Email, userTemp.Email))  // Compare Email usando String.Equals 
                {
                    Console.WriteLine("email e igual");

                    if (String.Equals(valid.Password, userTemp.Password)) // Compare Senha usando String.Equals 
                    {
                        CookieSet("1");  // Chama a função Cookies para armazenar a usuario logado

                        return RedirectToAction("Index", "Home");
                    }
                    
                    else
                    {
                         return RedirectToAction("Login");
                    }

                }
                else
                {
                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult CookieSet(string id)
        {
            Response.Cookies.Add(new HttpCookie("Logged", "1"));
           
            return RedirectToAction("Validation");

        }
       
        public ActionResult CookieGet()
        {
            HttpCookie cookie = Request.Cookies.Get("Logged");

            return View();
        }
       
    }
}