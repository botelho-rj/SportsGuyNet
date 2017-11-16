using Modelo.Tabelas;
using Servico.Tabelas;
using System.Net;
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


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var preferencia = preferenciaServico.ObterPreferencia((int)id);

            if (preferencia == null)
                return HttpNotFound();

            return View(preferencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var preferencia = preferenciaServico.RemoverPreferencia(id);
                TempData["Message"] = "A Preferencia " + preferencia.PreferenciaId + " foi removida.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }
}