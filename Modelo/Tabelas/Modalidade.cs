using SportsGuyNet.Modelo.Cadastros.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsGuyNet.Modelo.Tabelas.Models
{
    public class Modalidade
    {
        [Key]
        public int ModalidadeId { get; set; }

        [Display(Name = "Modalidade")]
        public string Nome { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

    }
}