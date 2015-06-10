using LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Repositorio
{
    /// <summary>
    /// Classe onde são referenciadas todas as classes
    /// </summary>
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Mapear as classes com os nomes das tabelas no banco
            modelBuilder.Entity<Produto>().ToTable("Produtos");//Para o Entity a tabela se chama Produto mas no banco de dados ela se chama Produtos
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
        }
    }
}
