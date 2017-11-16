using Modelo.Cadastros.Models;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas
{
    public class Preferencia
    {
        [Key]
        [Display(Name ="ID Preferência")]
        public int PreferenciaId { get; set; }

        [Display(Name = "ID Usuário")]
        public string UsuarioId { get; set; }

        [Display(Name = "ID Evento")]
        public int EventoId { get; set; }

        public Evento Evento { get; set; }

    }
}
