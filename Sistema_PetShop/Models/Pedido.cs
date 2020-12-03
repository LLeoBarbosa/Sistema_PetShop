using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{

    [Table("Pedidos")]
    public class Pedido
    {

        [Key]
        public int NumeroPedido { get; set; }

        [Key]
        public DateTime DataVenda { get; set; }


        [Required]
        [StringLength(100)]
        public string Detalhes { get; set; }

        [StringLength(100)]
        public string CarrinhoCompraId { get; set; }
        //*******************************************
        //*******************************************


        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        //*******************************************
        //*******************************************

        public List<IntercProdutoPedido> ItensProdutoNotas { get; set; }

        public List<IntercPagamentoPedido> PagamentoNotas { get; set; }


    }
}
