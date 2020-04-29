using ClimaAvi.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{

    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao

        List<User> userTemp = new List<User>(); // declarando a lista temporaria para login

        public ActionResult Index(string id)
        {
            Response.Cookies.Add(new HttpCookie("Logged", "1"));

            return RedirectToAction("Validation");
        }

        public ActionResult CookieGet()      // Como usar ?
        {
            HttpCookie cookie = Request.Cookies.Get("Logged");

            return RedirectToAction("/Home/Index");
        }


        public ActionResult Validation_Login(User userTemp)
        {
            List<User> users; 

            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado


            foreach (var valid in users)
            {

                if (String.Equals(valid.Email, userTemp.Email))  // Compare Email usando String.Equals 
                {
                    Console.WriteLine("email e igual");

                    if (String.Equals(valid.Password, userTemp.Password)) // Compare Senha usando String.Equals 
                    {
                        Index("1");  // Chama a função Cookies para armazenar a usuario logado

                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        return RedirectToAction("Login", "Usuario");
                    }

                }
              
            }

            return RedirectToAction("Login", "Usuario");
        }
        public ActionResult Validation_Create_User(User userTemp)
        {
            List<User> users; 

            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado

            users.Add(userTemp); // Adicionamos os dados informados do novo usuario na lista users

            Session["users"] = users;  // atribuimos a lista atualizada de usuários para a sessão, Global.asax 

           
            // Acrescentar regras de validação para criação do usuario.


            return RedirectToAction("Index", "Usuario");    // Como atualizar a lista de usuários na tela de Login?
        }

    }
}