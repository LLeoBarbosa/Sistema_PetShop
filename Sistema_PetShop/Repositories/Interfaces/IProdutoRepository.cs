using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Interfaces
{
    public interface IProdutoRepository
    {

        IEnumerable<Produto> Produtos { get; }

        Produto GetProdutoById(int produtoId);

    }
}
