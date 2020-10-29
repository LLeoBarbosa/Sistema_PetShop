using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class Produto
    {
        
        [Key]
        [Required]
        public int ProdutoId { get; set; }

        [StringLength(50)]
        public string DescricaoCurta { get; set; }

        [StringLength(200)]
        public string DescricaoDetalhada { get; set; }

        public decimal Peso { get; set; }

        [StringLength(50)]
        public string Fabricante { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Validade { get; set; }

        [Range(0,9999.99)]
        public decimal Preco { get; set; }

        [StringLength(200)]
        public string ImagemProduto { get; set; }

        
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public List<IntercProdutoNota> ItensProdutoNotas { get; set; }              



    }
}
