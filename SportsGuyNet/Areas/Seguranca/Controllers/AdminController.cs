using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SportsGuyNet.Areas.Seguranca.Models;
using SportsGuyNet.Areas.Seguranca.Models.SegurancaViewModelos;
using SportsGuyNet.Infraestrutura;
using System.Web;
using System.Web.Mvc;

namespace SportsGuyNet.Areas.Seguranca.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }


        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario { UserName = model.Nome, Email = model.Email };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }

            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
