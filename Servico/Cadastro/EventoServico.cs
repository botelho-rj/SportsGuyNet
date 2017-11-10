using Persistencia.DAL.Cadastros;
using System.Linq;
using Modelo.Cadastros.Models;

namespace Servico.Cadastro
{
    public class EventoServico
    {
        private EventoDAL eventoDal = new EventoDAL();

        public IQueryable ObterEventosClassificadosPorData()
        {
            return eventoDal.ObterEventosClassificadosPorData();
        }

        public Evento ObterEvento(int id)
        {
            return eventoDal.ObterEvento(id);
        }

        public void GravarEvento(Evento evento)
        {
            eventoDal.GravarEvento(evento);
        }

        public Evento RemoverEvento(int id)
        {
            return eventoDal.EliminarEventoPorId(id);
        }

        public void GravarInteresse(Evento evento)
        {
            eventoDal.GravarInteresse(evento);
        }
    }
}
