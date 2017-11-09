using SportsGuyNet.Modelo.Tabelas.Models;
using SportsGuyNet.Persistencia.Context;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL.Tabelas
{
    public class ModalidadeDAL
    {
        EFContext contexto = new EFContext();

        public IQueryable ObterModalidadesClassificadasPorNome()
        {
            return contexto.Modalidades.OrderBy(b => b.Nome);
        }

        public Modalidade ObterModalidade(int id)
        {
            return contexto.Modalidades.Where(p => p.ModalidadeId == id).First();
        }

        public void GravarModalidade(Modalidade modalidade)
        {
            if (modalidade.ModalidadeId == 0)
                contexto.Modalidades.Add(modalidade);
            else
                contexto.Entry(modalidade).State = EntityState.Modified;
            contexto.SaveChanges();
        }


        public Modalidade EliminarModalidade(int id)
        {
            Modalidade modalidade = ObterModalidade(id);
            contexto.Modalidades.Remove(modalidade);
            contexto.SaveChanges();
            return modalidade;
        }
    }
}
