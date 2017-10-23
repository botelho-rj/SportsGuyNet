using Microsoft.AspNet.Identity.Owin;
using SportsGuyNet.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
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


  }
}
