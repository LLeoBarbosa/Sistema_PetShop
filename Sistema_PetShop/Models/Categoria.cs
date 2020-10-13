using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        public string ImagemCategoria { get; set; }

        public List<Produto> Produtos { get; set; }


    }
}
