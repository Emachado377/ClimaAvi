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
           User userTemp = new User();

           return View(userTemp);
        }

        public ActionResult ForgotPassord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validation_Login(User userTemp)
        {
            List<User> users;
            users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado

            foreach (var valid in users)
            {

                if (String.Equals(valid.Email, userTemp.Email) && (String.Equals(valid.Password, userTemp.Password))) 
                {                  
                  return RedirectToAction("Index", "Home");
                }                                            
            }

            // ACRESCENTAR AQUI UMA CHAMADA PARA MSG DE ERRO APRESENTAR NA TELA - " E-MAIL OU SENHA INVALIDO"

            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost]
        public ActionResult Validation_Create_User(User userTemp)
        {
            if (ModelState.IsValid == false)
            {
                return View("Register", userTemp);
            }
            else
            {
                List<User> users = new List<User>();

                users = (List<User>)Session["users"]; // atribuindo a sessão com um casting forçado

                foreach (var busca in users)
                {
                    if (String.Equals(busca.Email, userTemp.Email))
                    {
                        // ACRESCENTAR AQUI UMA CHAMADA PARA MSG DE ERRO APRESENTAR NA TELA - " E-MAIL JÁ EXISTE"

                        return View("Register", userTemp);
                    }

                }
                users.Add(userTemp); // Adicionamos os dados informados do novo usuario na lista users

                Session["users"] = users;  // atribuimos a lista atualizada de usuários para a sessão, Global.asax 

                return RedirectToAction("Index", "Usuario");    // Como atualizar a lista de usuários na tela de Login?               
            }
        }
    }
}