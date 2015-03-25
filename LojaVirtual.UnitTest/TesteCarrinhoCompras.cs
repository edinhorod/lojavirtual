using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaVirtual.Dominio.Entidade;

namespace LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste Adicionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            /* PARA TESTAR
             menu TEST->Windows->Test Explorer
             */

            //Arrange = criação dos produtos
            Produto pro1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto pro2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Arrange = criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(pro1, 2);
            carrinho.AdicionarItem(pro2, 3);

            //Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);//Testando se tem 2 arquivos (pro1 e pro2) no carrinho
            Assert.AreEqual(itens[0].Produto, pro1);//Testando se produto na posição 0 é igual ao pro1
            Assert.AreEqual(itens[1].Produto, pro2);//Testando se produto na posição 1 é igual ao pro2

        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            //Arrange = criação dos produtos
            Produto pro1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto pro2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            //Produto pro3 = new Produto
            //{
            //    ProdutoId = 3,
            //    Nome = "Teste 3"
            //};

            //Arrange = criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(pro1, 1);
            carrinho.AdicionarItem(pro2, 1);
            carrinho.AdicionarItem(pro1, 10);

            //Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 11);

        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            //Arrange = criação dos produtos
            Produto pro1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto pro2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Produto pro3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            //Arrange = criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(pro1, 1);
            carrinho.AdicionarItem(pro2, 3);
            carrinho.AdicionarItem(pro3, 5);
            carrinho.AdicionarItem(pro2, 1);

            carrinho.RemoverItem(pro2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == pro2).Count(), 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            //Arrange = criação dos produtos
            Produto pro1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto pro2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange = criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(pro1, 1);
            carrinho.AdicionarItem(pro2, 1);
            carrinho.AdicionarItem(pro1, 4);

            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 450M);

            
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            //Arrange = criação dos produtos
            Produto pro1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto pro2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            //Arrange = criação do carrinho
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(pro1, 1);
            carrinho.AdicionarItem(pro2, 1);

            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
