using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{

    [Table("Pagamentos_Pedidos")]
    public class IntercPagamentoPedido
    {

        [Key]
        //[ForeignKey("NumeroNota")]
        public int NumeroPedido { get; set; }


        [Key]
        //[ForeignKey("DataVenda")]
        public DateTime DataVenda { get; set; }

        public Pedido Pedidos { get; set; }

        //***********************************************
        //***********************************************
        
        [Key]
        [ForeignKey("TipoPagamentoId")]
        public int TipoPagamentoId { get; set; }

        public TipoPagamento TipoPagamento { get; set; }


        [Required]
        public decimal ValorPago { get; set; }

        public string NumeroTransacao { get; set; }




    }
}
