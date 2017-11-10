using Modelo.Tabelas.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        public int? ModalidadeId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [Display(Name = "Título")]
        [StringLength(100, ErrorMessage = "O título do evento precisa	ter	no	mínimo 3 caracteres", MinimumLength = 3)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O horário é obrigatório.")]
        [Display(Name = "Horário")]
        [DataType(DataType.Time)]
        public TimeSpan Horario { get; set; }

        public Modalidade Modalidade { get; set; }





    }
}
