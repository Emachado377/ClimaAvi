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

       public ActionResult Index(string id)
        {
           //Response.Cookies.Add(new HttpCookie("Logged", "1"));

            return RedirectToAction("Validation");
        }

        public ActionResult CookieGet()      // Como usar ?
        {
            //HttpCookie cookie = Request.Cookies.Get("Logged");

            return RedirectToAction("/Home/Index");
        }      
    }
}