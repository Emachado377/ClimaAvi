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

        //List<User> userTemp = new List<User>(); // declarando a lista temporaria para login

        public ActionResult Validation(User userTemp)
        {
           
            APIHttpClient client = new APIHttpClient("http://localhost:52198/api/");
            var users = client.Get<List<User>>("User/");

            foreach (var valid in users)
            {
                if (String.Equals(valid.Email, userTemp.Email))  // Compare Email usando String.Equals 
                {
                    Console.WriteLine("email e igual");

                    if (String.Equals(valid.Password, userTemp.Password)) // Compare Senha usando String.Equals 
                    {
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

    }
}