using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsGuyNet.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        public int? ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Horário")]
        public TimeSpan Horario { get; set; }




    }
}