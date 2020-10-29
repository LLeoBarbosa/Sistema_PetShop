using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{

    [Table("IntercProdutoNota")]
    public class IntercProdutoNota
    {

        [Key]
        //[ForeignKey("NumeroNota")]
        //[Column(Order = 1)]
        public int NumeroNota { get; set; }


        [Key]
        //[ForeignKey("DataVenda")]
        //[Column(Order = 2)]
        public DateTime DataVenda { get; set; }

        public NotaFiscal NotaFiscal { get; set; }

        //***********************************************
        //***********************************************

        [Key]
        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }  

        public Produto Produto { get; set; }

        //***********************************************
        //***********************************************


        [Required]
        public int QTDVendida { get; set; }

       


    }
}
