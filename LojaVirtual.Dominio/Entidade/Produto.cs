using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public string Categoria { get; set; }


    }
}
