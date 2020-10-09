using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class Produtos
    {
        
        public int ProdutoId { get; set; }

        public string DescricaoCurta { get; set; }

        public string DescricaoDetalhada { get; set; }

        public decimal Peso { get; set; }

        public string Fabricante { get; set; }

        public DateTime Validade { get; set; }

        public decimal Preco { get; set; }

        public string ImagemProduto { get; set; }


        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }



    }
}
