using Microsoft.EntityFrameworkCore;
using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Context
{
    public class AplicacaoDbContext : DbContext
    {

        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ItensCarrinhoCompra> ItensCarrinhoCompras { get; set; }

        //******************************************************************************************

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        public DbSet<TipoPagamento> TiposPagamentos { get; set; }

        public DbSet<IntercPagamentoNota> Pagamentos_Notas { get; set; }

        public DbSet<IntercProdutoNota> Produtos_Notas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NotaFiscal>(nf => nf.HasKey(chave => new
            {
                chave.NumeroNota,
                chave.DataVenda
            }));

            //*******************************************************************

            modelBuilder.Entity<IntercProdutoNota>(ipn => ipn.HasKey(chave => new
            {
                chave.NumeroNota,
                chave.DataVenda,
                chave.ProdutoId
   
            }));

            modelBuilder.Entity<IntercProdutoNota>()
                .HasOne(nf => nf.NotaFiscal)
                .WithMany(ipn => ipn.ItensProdutoNotas)
                .HasForeignKey(ipn => new
                {
                    ipn.NumeroNota,
                    ipn.DataVenda,
                    
                });

            //*******************************************************************

            modelBuilder.Entity<IntercPagamentoNota>(np => np.HasKey(chave => new
            {
                chave.NumeroNota,
                chave.DataVenda,
                chave.TipoPagamentoId
            }));

            modelBuilder.Entity<IntercPagamentoNota>()
               .HasOne(nf => nf.NotaFiscal)
               .WithMany(ipn => ipn.PagamentoNotas)
               .HasForeignKey(ipn => new
               {
                   ipn.NumeroNota,
                   ipn.DataVenda,
                   
               });

            //*******************************************************************


        }



    }
}
