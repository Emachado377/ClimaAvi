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
            
            APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
            users = client.Get<List<User>>("User");

            foreach (var valid in users)
           {
             if (String.Equals(valid.Email, userTemp.Email) && (String.Equals(valid.Password, userTemp.Password)))
                {
                    return Json(new Mensagem()
                    {
                        MensagemErro = false,                       
                    });
                }
            }              
            return Json(new Mensagem()
            {
                MensagemErro = true,
                MensagemTexto = "Senha ou Email Invalido!"
            });
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
                
               APIHttpClient client = new APIHttpClient("https://localhost:44313/api/");
               var users = client.Get<List<User>>("user");


                foreach (var busca in users)
                {
                    if (String.Equals(busca.Email, userTemp.Email))
                    {
                       ModelState.AddModelError("userTemp.CadastroErrado", "E-mail já Existe !");
                       return View("Register", userTemp);
                    }

                }
                
                client.Post<User>("user", userTemp);

                return RedirectToAction("Index", "Usuario");    // Como atualizar a lista de usuários na tela de Login?               
            }
        }
    }
}