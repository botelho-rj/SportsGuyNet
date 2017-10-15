using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsGuyNet.Models
{
    public class Autenticacao
    {   
        [Key]
        public int AutenticacaoId { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Erro. As senhas diferem.")]
        [DataType(DataType.Password)]
        public string SenhaIgual { get; set; }

    }
}