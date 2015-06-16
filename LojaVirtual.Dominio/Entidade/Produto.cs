using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição do produto")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o valor do produto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria do produto")]
        public string Categoria { get; set; }

        public byte[] Imagem{ get; set; }

        public string ImagemMimeType { get; set; }
    }
}
