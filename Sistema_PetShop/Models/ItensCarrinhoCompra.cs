using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class ItensCarrinhoCompra
    {

        [Key]
        public int ItemCarrinhoId { get; set; }

        public Produto Produto { get; set; }

        public  int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

    }
}
