using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoqueAplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe seu usuário")]
        [Display(Name ="Usuário: ")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Informe sua Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha: ")]
        public string Senha { get; set; }

        [Display(Name = "Lembrar Me")]
        public bool LembrarMe { get; set; }
    }
}