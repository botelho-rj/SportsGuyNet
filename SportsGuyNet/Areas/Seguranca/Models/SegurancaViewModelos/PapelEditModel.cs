using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsGuyNet.Areas.Seguranca.Models.SegurancaViewModelos
{
  public class PapelEditModel
  {
    public Papel Role { get; set; }
    public IEnumerable<Usuario> Membros { get; set; }
    public IEnumerable<Usuario> NaoMembros { get; set; }
  }

  public class PapelModificationModel
  {
    [Required]
    public string NomePapel { get; set; }
    public string[] IdsParaAdicionar { get; set; }
    public string[] IdsParaRemover { get; set; }

  }
}
