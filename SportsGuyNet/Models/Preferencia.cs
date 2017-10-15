using System.ComponentModel.DataAnnotations;

namespace SportsGuyNet.Models
{
    public class Preferencia
    {
        [Key]
        public int PreferenciaId { get; set; }

        public int AutenticacaoId { get; set; }
        public Autenticacao Usuario { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }


    }
}