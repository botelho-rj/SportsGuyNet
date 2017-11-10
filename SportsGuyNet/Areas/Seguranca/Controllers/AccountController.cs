using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SportsGuyNet.Areas.Seguranca.Models;
using SportsGuyNet.Areas.Seguranca.Models.SegurancaViewModelos;
using SportsGuyNet.Infraestrutura;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SportsGuyNet.Areas.Seguranca.Controllers
{
    public class AccountController : Controller
    {


        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        #region LOGIN

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find(details.Nome, details.Senha);

                if (user == null)
                {
                    ModelState.AddModelError("", "Nome ou senha inválido(s).");
                }

                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    Session["UserId"] = ident.GetUserId();                    
                    return RedirectToAction("Index", "../Cadastros/Eventos");
                }
            }
            return View(details);
        }
        #endregion

        #region METODOS AUXILIARES

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager
                <GerenciadorUsuario>();
            }
        }

        #endregion


    }
}

