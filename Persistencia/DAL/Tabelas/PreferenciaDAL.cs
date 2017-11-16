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
            return contexto.Preferencias.OrderBy(c => c.PreferenciaId);
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
