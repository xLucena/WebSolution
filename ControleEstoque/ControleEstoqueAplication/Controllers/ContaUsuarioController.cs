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
        //esta passando o allownanonymous para todo mundo acessar 
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //Quando logar, vai voltar para a URL PRIVADA AO SE LOGAR
            ViewBag.ReturnUrl = returnUrl;
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        
        //criando o methodo POST possuindo 2 parametros -> Login e a URL de retorno ao logar
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            //Validando o login do usuario, se tiver invalido, vai retornar a tela de LOGIN, se estiver correto, vai retornar o menu todo Authorized
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
            // se n achar o login
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
