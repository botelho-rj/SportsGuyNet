using Modelo.Tabelas;
using Persistencia.Context;
using System.Linq;


namespace Persistencia.DAL.Tabelas
{
    public class PreferenciaDAL
    {
        EFContext contexto = new EFContext();

        public IQueryable ObterPreferenciasClassificadasPorData()
        {   
            var preferencias = contexto.Preferencias.Include("Evento").OrderBy(c => c.PreferenciaId);
            return preferencias;
        }

        public Preferencia ObterPreferencia(int id)
        {
            return contexto.Preferencias.Where(p => p.PreferenciaId == id)
                .First();
        }

        public Preferencia RemoverPreferencia(int id)
        {
            Preferencia preferencia = ObterPreferencia(id);
            contexto.Preferencias.Remove(preferencia);
            contexto.SaveChanges();
            return preferencia;
        }

    }
}
