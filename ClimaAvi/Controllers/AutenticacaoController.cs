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

        public ActionResult CookieGet()
        {
            HttpCookie cookie = Request.Cookies.Get("Logged");

            return RedirectToAction("/Home/Index");
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
                        Index("1");  // Chama a função Cookies para armazenar a usuario logado

                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        return RedirectToAction("Login", "Usuario");
                    }

                }
                else
                {
                    return RedirectToAction("Login", "Usuario");
                }
            }

            return RedirectToAction("Login", "Usuario");
        }

//       public ActionResult Index(string id)
//        {
//           //Response.Cookies.Add(new HttpCookie("Logged", "1"));

//            return RedirectToAction("Validation");
//        }

//        public ActionResult CookieGet()      // Como usar ?
//        {
//            //HttpCookie cookie = Request.Cookies.Get("Logged");

//            return RedirectToAction("/Home/Index");
//        }      
//>>>>>>> 326a7a0e8cb13f73c7054fd64cb2c269ed0f4aef
    }
}