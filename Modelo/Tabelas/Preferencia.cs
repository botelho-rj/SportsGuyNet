using Modelo.Cadastros.Models;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas
{
    public class Preferencia
    {
        [Key]
        public int PreferenciaId { get; set; }
        public string UsuarioId { get; set; }
        public int EventoId { get; set; }

        public Evento Evento { get; set; }

    }
}
