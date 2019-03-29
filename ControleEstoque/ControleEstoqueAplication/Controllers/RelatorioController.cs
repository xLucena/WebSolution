using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoqueAplication.Controllers
{
    public class RelatorioController : Controller
    {
        [Authorize]
        public ActionResult PosicaoEstoque()
        {
            return View();
        }
        [Authorize]
        public ActionResult Pcompras()
        {
            return View();
        }
    }
}