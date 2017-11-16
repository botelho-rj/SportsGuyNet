using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;

namespace Servico.Tabelas
{

    public class PreferenciaServico
    {
        private PreferenciaDAL preferenciaDAL = new PreferenciaDAL();

        public IQueryable ObterPreferenciasClassificadasPorData()
        {
            return preferenciaDAL.ObterPreferenciasClassificadasPorData();
        }

        public Preferencia ObterPreferencia(int id)
        {
            return preferenciaDAL.ObterPreferencia(id);
        }

        public Preferencia RemoverPreferencia(int id)
        {
            return preferenciaDAL.RemoverPreferencia(id);
        }

    }
}
