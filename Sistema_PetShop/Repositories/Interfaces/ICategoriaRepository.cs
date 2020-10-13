using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {

        IEnumerable<Categoria> Categorias { get; }

    }
}
