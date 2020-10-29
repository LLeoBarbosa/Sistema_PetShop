using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{

    [Table("NotasFiscais")]
    public class NotaFiscal
    {

        [Key]     
        public int NumeroNota { get; set; }

        [Key]
        public DateTime DataVenda { get; set; }
               

        [Required]
        [StringLength(100)]
        public string Detalhes { get; set; }

        //*******************************************
        //*******************************************


        [ForeignKey("ClienteId")]
        public int CLienteId { get; set; }

        public Cliente Cliente { get; set; }

        //*******************************************
        //*******************************************

        public List<IntercProdutoNota> ItensProdutoNotas { get; set; }

        public List<IntercPagamentoNota> PagamentoNotas { get; set; }

       
    }
}
