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


            return View();
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