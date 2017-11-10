using Persistencia.DAL.Tabelas;
using Modelo.Tabelas.Models;
using System.Linq;

namespace Servico.Tabelas
{
    public class ModalidadeServico
    {
        private ModalidadeDAL modalidadeDAL = new ModalidadeDAL();

        public IQueryable ObterModalidadesClassificadasPorNome()
        {
            return modalidadeDAL.ObterModalidadesClassificadasPorNome();
        }

        public Modalidade ObterModalidade(int id)
        {
            return modalidadeDAL.ObterModalidade(id);
        }

        public void GravarModalidade(Modalidade modalidade)
        {
            modalidadeDAL.GravarModalidade(modalidade);
        }

        public Modalidade EliminarModalidade(int id)
        {
            return modalidadeDAL.EliminarModalidade(id);
        }
    }
}
