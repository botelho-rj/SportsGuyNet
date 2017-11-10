using Persistencia.DAL.Tabelas;
using System.Linq;

namespace Servico.Tabelas
{

    public class PreferenciaServico
    {
        private PreferenciaDAL preferenciaDAL = new PreferenciaDAL();

        public IQueryable ObterPreferenciasClassificadasPorData(string idUsuario)
        {
            return preferenciaDAL.ObterPreferenciasClassificadasPorData(idUsuario);
        }

    }
}
