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

       
    }
}
