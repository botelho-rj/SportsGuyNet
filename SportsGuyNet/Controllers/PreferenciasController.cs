using SportsGuyNet.Context;
using SportsGuyNet.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SportsGuyNet.Controllers
{
    public class PreferenciasController : Controller
    {
        EFContext contexto = new EFContext();

        // GET: Preferencias
        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["UsuarioId"]);

            if (Session["UsuarioId"] == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var preferencias = contexto.Preferencias.Where(s => s.AutenticacaoId == id)
                                                    .Include(c => c.Evento.Modalidade)
                                                    .OrderBy(d => d.Evento.Data);
            return View(preferencias);
        }
        
                
        #region DELETE
        //GET: DELETE
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var preferencia = contexto.Preferencias.Find(id);

            //var eventoId = preferencia.EventoId;
            //var evento = contexto.Eventos.Where(c => c.EventoId == eventoId).Include(c => c.Modalidade).First();

            if (preferencia == null)
                return HttpNotFound();

            return View(preferencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var preferencia = contexto.Preferencias.Find(id);
            contexto.Preferencias.Remove(preferencia);
            contexto.SaveChanges();
            TempData["Message"] = "O Evento " + preferencia.Evento.Titulo.ToUpper() + " foi tirado da sua lista de interesses .";
            
            return RedirectToAction("Index");

        }
        #endregion
    }
}