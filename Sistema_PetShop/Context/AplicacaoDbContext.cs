using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public AplicacaoDbContext()
        {

        }
        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options) : base(options) { }


        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ItensCarrinhoCompra> ItensCarrinhoCompras { get; set; }

        //******************************************************************************************

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<TipoPagamento> TiposPagamentos { get; set; }

        public DbSet<IntercPagamentoPedido> Pagamento_Pedidos { get; set; }

        public DbSet<IntercProdutoPedido> Produtos_Pedidos { get; set; }

        //******************************************************************************************

        public DbSet<Usuario> Usuarios { get; set; }

        //******************************************************************************************

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pedido>(nf => nf.HasKey(chave => new
            {
                chave.NumeroPedido,
                chave.DataVenda
            }));

            //*******************************************************************

            modelBuilder.Entity<IntercProdutoPedido>(ipn => ipn.HasKey(chave => new
            {
                chave.NumeroPedido,
                chave.DataVenda,
                chave.ProdutoId
   
            }));

            modelBuilder.Entity<IntercProdutoPedido>()
                .HasOne(nf => nf.Pedidos)
                .WithMany(ipn => ipn.ItensProdutoNotas)
                .HasForeignKey(ipn => new
                {
                    ipn.NumeroPedido,
                    ipn.DataVenda,
                    
                });

            //*******************************************************************

            modelBuilder.Entity<IntercPagamentoPedido>(np => np.HasKey(chave => new
            {
                chave.NumeroPedido,
                chave.DataVenda,
                chave.TipoPagamentoId
            }));

            modelBuilder.Entity<IntercPagamentoPedido>()
               .HasOne(nf => nf.Pedidos)
               .WithMany(ipn => ipn.PagamentoNotas)
               .HasForeignKey(ipn => new
               {
                   ipn.NumeroPedido,
                   ipn.DataVenda,
                   
               });

            //*******************************************************************


        }



    }
}
