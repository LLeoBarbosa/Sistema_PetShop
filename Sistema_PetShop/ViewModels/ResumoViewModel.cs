using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.ViewModels
{
    public class ResumoViewModel
    {

        public Cliente _Cliente { get; set; }

        public Produto _Produto { get; set; }

        public decimal TotalPedido { get; set; }

        public IEnumerable<IntercProdutoPedido> _IntercProdutoPedido { get; set; }

    }
}
