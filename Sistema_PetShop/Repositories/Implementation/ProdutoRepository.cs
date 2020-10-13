using Microsoft.EntityFrameworkCore;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Implementation
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        public ProdutoRepository(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        //*********************************************************************************************************
        //*********************************************************************************************************

        public IEnumerable<Produto> Produtos => _aplicacaoDbContext.Produtos.Include(p => p.Categoria);

        public Produto GetProdutoById(int produtoId)
        {
            return _aplicacaoDbContext.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
        }
    }
}
