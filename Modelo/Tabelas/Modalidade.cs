using Modelo.Cadastros.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas.Models
{
    public class Modalidade
    {
        [Key]
        public int ModalidadeId { get; set; }

        [Display(Name = "Modalidade")]
        [StringLength(100, ErrorMessage = "A modalidade precisa	ter	no	mínimo 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe	a modalidade")]
        public string Nome { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

    }
}
