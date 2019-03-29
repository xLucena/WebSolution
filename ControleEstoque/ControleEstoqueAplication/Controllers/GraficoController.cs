using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoqueAplication.Controllers
{
    public class GraficoController : Controller
    {
        [Authorize]

        public ActionResult Perdas()
        {
            return View();
        }
        [Authorize]
        public ActionResult EntradasSaidaMes()
        {
            return View();
        }
    }
}