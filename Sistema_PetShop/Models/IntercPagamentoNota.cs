using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{

    [Table("IntercPagamentoNota")]
    public class IntercPagamentoNota
    {

        [Key]
        //[ForeignKey("NumeroNota")]
        public int NumeroNota { get; set; }


        [Key]
        //[ForeignKey("DataVenda")]
        public DateTime DataVenda { get; set; }

        public NotaFiscal NotaFiscal { get; set; }

        //***********************************************
        //***********************************************
        
        [Key]
        [ForeignKey("TipoPagamentoId")]
        public int TipoPagamentoId { get; set; }

        public TipoPagamento TipoPagamento { get; set; }


        [Required]
        public decimal ValorPago { get; set; }




    }
}
