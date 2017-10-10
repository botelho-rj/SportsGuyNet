using SportsGuyNet.Context;
using SportsGuyNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SportsGuyNet.Controllers
{
    public class ModalidadesController : Controller
    {
        EFContext contexto = new EFContext();

        // GET: Modalidades
        public ActionResult Index()
        {
            return View(contexto.Modalidades.OrderBy(c => c.Nome));
        }

        // GET: Modalidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modalidades/Create
        [HttpPost]
        public ActionResult Create(Modalidade modalidade)
        {
            try
            {
                contexto.Modalidades.Add(modalidade);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(modalidade);
            }
        }

        // GET: Modalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var modalidade = contexto.Modalidades.Find(id);

            if (modalidade == null)
                return HttpNotFound();

            return View(modalidade);
        }

        // POST: Modalidades/Edit/5
        [HttpPost]
        public ActionResult Edit(Modalidade modalidade)
        {
            try
            {
                contexto.Entry(modalidade).State = EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var modalidade = contexto.Modalidades.Find(id);

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
                var modalidade = contexto.Modalidades.Find(id);
                contexto.Modalidades.Remove(modalidade);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
