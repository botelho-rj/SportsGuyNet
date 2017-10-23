using Servico.Cadastro;
using Servico.Tabelas;
using SportsGuyNet.Modelo.Cadastros.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace SportsGuyNet.Areas.Cadastros.Controllers
{
  public class EventosController : Controller
    {

        private EventoServico eventoServico = new EventoServico();
        private ModalidadeServico modalidadeServico = new ModalidadeServico();

        private void PopularViewBag(Evento evento = null)
        {
            if (evento == null)
            {
                ViewBag.ModalidadeId = new SelectList(modalidadeServico.ObterModalidadesClassificadasPorNome(), "ModalidadeId", "Nome");
            }
            else
            {
                ViewBag.ModalidadeId = new SelectList(modalidadeServico.ObterModalidadesClassificadasPorNome(), "ModalidadeId", "Nome", evento.ModalidadeId);
            }
        }

        private ActionResult GravarEvento(Evento evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventoServico.GravarEvento(evento);
                    PopularViewBag(evento);
                    return RedirectToAction("Index");
                }
                PopularViewBag(evento);
                return View(evento);
            }
            catch
            {
                PopularViewBag(evento); 
                return View(evento);
            }
        }


        #region INDEX

        // GET: Eventos
        public ActionResult Index()
        {
            return View(eventoServico.ObterEventosClassificadosPorData());
        }
        #endregion

        #region CREATE
        //GET: CREATE
        public ActionResult Create()
        {
            PopularViewBag();      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            GravarEvento(evento);
            return RedirectToAction("Index");
        }
        #endregion

    /*
        #region RESERVE
        //GET: RESERVE
        public ActionResult Reserve(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = eventoServico.ObterEvento((int)id);

            if (evento == null)
                return HttpNotFound();

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve(Evento evento)
        {
            if (ModelState.IsValid)
            {
                Preferencia preferencia = new Preferencia();
                preferencia.AutenticacaoId = Convert.ToInt32(Session["UsuarioId"]);
                preferencia.EventoId = evento.EventoId;
                contexto.Preferencias.Add(preferencia);
                contexto.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(evento);
        }
        #endregion

      */

/*
        #region DETAILS
        //GET: DETAILS
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = contexto.Eventos.Where(c => c.EventoId == id).Include(c => c.Modalidade).First();

            if (evento == null)
                return HttpNotFound();

            return View(evento);
        }
        #endregion
*/


        #region EDIT
        //GET: EDIT
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = eventoServico.ObterEvento((int)id);

            if (evento == null)
                return HttpNotFound();

            PopularViewBag(evento);       

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                GravarEvento(evento);
                return RedirectToAction("Index");
            }
            
            return View(evento);
        }
        #endregion

        #region DELETE
        //GET: DELETE
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = eventoServico.ObterEvento((int)id);

            if (evento == null)
                return HttpNotFound();

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var evento = eventoServico.RemoverEvento(id);
                TempData["Message"] = "O Evento " + evento.Titulo.ToUpper() + " foi removido.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            

        } 
        #endregion

    }
}
