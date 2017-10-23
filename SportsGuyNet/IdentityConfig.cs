using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SportsGuyNet.DAL;
using SportsGuyNet.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsGuyNet
{
  public class IdentityConfig
  {
    public void Configuration(IAppBuilder app)
    {
      app.CreatePerOwinContext<IdentityDbContextAplicacao>(IdentityDbContextAplicacao.Create);
      app.CreatePerOwinContext<GerenciadorUsuario>(GerenciadorUsuario.Create);
      app.UseCookieAuthentication(new CookieAuthenticationOptions {
                                          AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                                          LoginPath = new PathString("/Seguranca/Account/Login"),
                                          }
                                  );
    }

  }
  }