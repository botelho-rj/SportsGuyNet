﻿using Servico.Tabelas;
using System.Web.Mvc;

namespace SportsGuyNet.Areas.Tabelas.Controllers
{
    public class PreferenciasController : Controller
    {

        private PreferenciaServico preferenciaServico = new PreferenciaServico();

        #region INDEX

        // GET: Eventos
        public ActionResult Index()
        {                     
            return View(preferenciaServico.ObterPreferenciasClassificadasPorData());
        }
        #endregion
    }
}