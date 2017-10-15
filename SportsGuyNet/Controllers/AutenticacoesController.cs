using SportsGuyNet.Context;
using SportsGuyNet.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsGuyNet.Controllers
{
    public class AutenticacoesController : Controller
    {

        EFContext contexto = new EFContext();


        public ActionResult Index()
        {
            return View();
        }


        #region Registrar
        //
        // GET: Registrar
        public ActionResult Registrar()
        {
            return View();
        }

        //
        // POST: Registrar
        [HttpPost]
        public ActionResult Registrar(Autenticacao usuario)
        {
            if (ModelState.IsValid)
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();

            }

            return View("Login","Autenticacoes");
        }
        #endregion


        #region Login
        //
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: Login
        [HttpPost]
        public ActionResult Login(Autenticacao usuario)
        {
            var user = contexto.Usuarios.Single(e => e.Email == usuario.Email 
                                                  && e.Senha == usuario.Senha);
            if(user != null)
            {
                Session["UsuarioId"] = user.AutenticacaoId;
                return RedirectToAction("Index", "Eventos");
            }

            else
            {
                ModelState.AddModelError("","Email ou senha inválidos.");
            }
            return View();
        }
        #endregion

        

    }
}