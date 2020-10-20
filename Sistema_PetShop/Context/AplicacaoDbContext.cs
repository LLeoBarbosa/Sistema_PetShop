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

    }
}
