using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoqueAplication.Models
{
    public class GrupoProdutoModel
    {
        //Aqui vai utilizar pra fazer requisicao no bdo, trazer o ID,Nome e Ativo, e gravar tambem
        public int Id { get; set; }
        public String Nome { get; set; }
        public bool Ativo { get; set; }
    }
}