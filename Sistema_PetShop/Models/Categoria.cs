using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class Categoria
    {

        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string ImagemCategoria { get; set; }

        public List<Produtos> Produtos { get; set; }


    }
}
