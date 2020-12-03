using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class TipoPagamento
    {
                
        [Key]
        [Required]
        public int TipoPagamentoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required]
        public char Parcelado { get; set; }

        [Required]
        [StringLength(1)]
        public int QtdParcelas { get; set; }

        public decimal ValorMinimo { get; set; }

        public List<IntercPagamentoPedido> PagamentoPedidos { get; set; }



    }
}
