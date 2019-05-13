using ControleEstoqueAplication.Models;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//colocando no banco de dados 

namespace ControleEstoqueAplication.Controllers
{
    public class ContaUsuarioController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            //Validando o login do usuario, se tiver invalido, vai retornar a tela de LOGIN
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var achou = UsuarioModel.ValidarUsuario(login.Usuario, login.Senha);

            if (achou)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembrarMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Invalido.");
            }
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
           return RedirectToAction("Index","Home");

        }

    }
}
