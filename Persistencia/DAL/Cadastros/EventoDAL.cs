using SportsGuyNet.Modelo.Cadastros.Models;
using SportsGuyNet.Persistencia.Context;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL.Cadastros
{
    public class EventoDAL
    {
        EFContext contexto = new EFContext();


        public IQueryable ObterEventosClassificadosPorData()
        {
            var eventos = contexto.Eventos.Include(c => c.Modalidade).OrderBy(d => d.Data);
            return eventos;
        }


        public Evento ObterEvento(int id)
        {
            return contexto.Eventos.Where(p => p.EventoId == id)
                .Include(c => c.Modalidade)
                .First();
        }


        public void GravarEvento(Evento evento)
        {   
            if(evento.EventoId == 0)
                contexto.Eventos.Add(evento);

            else
                contexto.Entry(evento).State = EntityState.Modified;
            contexto.SaveChanges();
        }


        public Evento EliminarEventoPorId(int id)
        {
            Evento evento = ObterEvento(id);
            contexto.Eventos.Remove(evento);
            contexto.SaveChanges();
            return evento;
        }


    }
}
