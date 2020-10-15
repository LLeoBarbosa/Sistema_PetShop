using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.ViewModels
{
    public class CategoriaViewModel
    {

        public IEnumerable<Categoria> Categoria { get; set; }

        public string CategoriaAtual { get; set; }

    }
}
