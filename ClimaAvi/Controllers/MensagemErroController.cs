using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClimaAvi.Controllers
{
    public class MensagemErroController : Controller
    {
        // GET: MensagemErro
        public ActionResult ErroMsg(int id)
        {
            ViewBag.Status = id;

            return View();
        }
    }
}