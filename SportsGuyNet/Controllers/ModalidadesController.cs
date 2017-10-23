using Servico.Tabelas;
using SportsGuyNet.Context;
using SportsGuyNet.Modelo.Tabelas.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SportsGuyNet.Controllers
{
    public class ModalidadesController : Controller
    {
        private ModalidadeServico modalidadeServico = new ModalidadeServico();

        private ActionResult GravarModalidade(Modalidade modalidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    modalidadeServico.GravarModalidade(modalidade);
                    return RedirectToAction("Index");
                }
                return View(modalidade);
            }
            catch
            {
                return View(modalidade);
            }
        }


        #region INDEX
        // GET: Modalidades
        public ActionResult Index()
        {
            return View(modalidadeServico.ObterModalidadesClassificadasPorNome());
        }
        #endregion

        #region CREATE
        // GET: Modalidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modalidades/Create
        [HttpPost]
        public ActionResult Create(Modalidade modalidade)
        {          
            return GravarModalidade(modalidade);           
        }
        #endregion

        #region EDIT
        // GET: Modalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var modalidade = modalidadeServico.ObterModalidade((int)id);

            if (modalidade == null)
                return HttpNotFound();

            return View(modalidade);
        }

        // POST: Modalidades/Edit/5
        [HttpPost]
        public ActionResult Edit(Modalidade modalidade)
        {
            return GravarModalidade(modalidade);
        }
        #endregion

        #region DELETE
        // GET: Modalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var modalidade = modalidadeServico.ObterModalidade((int)id);

            if (modalidade == null)
                return HttpNotFound();

            return View(modalidade);
        }

        // POST: Modalidades/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Modalidade modalidade = modalidadeServico.EliminarModalidade(id);
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
