using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        public CategoriaRepository(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        public IEnumerable<Categoria> Categorias => _aplicacaoDbContext.Categorias.ToList();
    }

}
