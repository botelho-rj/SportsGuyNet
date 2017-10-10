using SportsGuyNet.Context;
using SportsGuyNet.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SportsGuyNet.Controllers
{
    public class EventosController : Controller
    {

        EFContext contexto = new EFContext();

        #region INDEX

        // GET: Eventos
        public ActionResult Index()
        {
            var eventos = contexto.Eventos.Include(c => c.Modalidade).OrderBy(d => d.Data);
            return View(eventos);
        }
        #endregion

        #region CREATE
        //GET: CREATE
        public ActionResult Create()
        {
            ViewBag.ModalidadeId = new SelectList(contexto.Modalidades.OrderBy(c => c.Nome), "ModalidadeId", "Nome");      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            contexto.Eventos.Add(evento);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

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

        #region EDIT
        //GET: EDIT
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var evento = contexto.Eventos.Find(id);

            if (evento == null)
                return HttpNotFound();

            ViewBag.ModalidadeId = new SelectList(contexto.Modalidades.OrderBy(c => c.Nome), "ModalidadeId", "Nome", evento.ModalidadeId);

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evento evento)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(evento).State = EntityState.Modified;
                contexto.SaveChanges();
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

            var evento = contexto.Eventos.Where(c => c.EventoId == id).Include(c => c.Modalidade).First();

            if (evento == null)
                return HttpNotFound();

            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var evento = contexto.Eventos.Find(id);
            contexto.Eventos.Remove(evento);
            contexto.SaveChanges();
            TempData["Message"] = "O Evento " + evento.Titulo.ToUpper() + " foi removido.";
            return RedirectToAction("Index");

        } 
        #endregion

    }
}