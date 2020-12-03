using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{

    [Table("Produtos_Pedidos")]
    public class IntercProdutoPedido
    {

        [Key]
        //[ForeignKey("NumeroNota")]
        //[Column(Order = 1)]
        public int NumeroPedido { get; set; }


        [Key]
        //[ForeignKey("DataVenda")]
        //[Column(Order = 2)]
        public DateTime DataVenda { get; set; }

        public Pedido Pedidos { get; set; }

        //***********************************************
        //***********************************************

        [Key]
        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        //***********************************************
        //***********************************************
        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int QTDVendida { get; set; }




    }
}
