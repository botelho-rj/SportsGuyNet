using Persistencia.Context;
using System.Linq;


namespace Persistencia.DAL.Tabelas
{
    public class PreferenciaDAL
    {
        EFContext contexto = new EFContext();

        public IQueryable ObterPreferenciasClassificadasPorData(string idUsuario)
        {          
            return contexto.Preferencias.Where(c => c.UsuarioId == idUsuario);
        }

       
    }
}
