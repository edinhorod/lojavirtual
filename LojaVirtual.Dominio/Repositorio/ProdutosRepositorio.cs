using LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //Salvar/Alterar Produto
        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                //Se produto receber o Id 0, então salva um NOVO produto
                _context.Produtos.Add(produto);
            }
            else
            {
                //Localiza o produto pelo Id
                Produto prod = _context.Produtos.Find(produto.ProdutoId);
                //Se existir o ProdutoId, altera o produto existente
                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                }
            }

            _context.SaveChanges();
        }
        
        //Excluir Produto
        public Produto Excluir(int produtoId)
        {
            Produto prod = _context.Produtos.Find(produtoId);
            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }
            return prod;
        }

    }
}
