using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoPago.Resources;

namespace Sistema_PetShop.ViewModels
{
    public class PedidoViewModel
    {


        //public PedidoViewModel(Cliente cliente, Produto produto)
        //{
        //    cliente = _Cliente;
        //    produto = _Produto;
        //}

        public Cliente _Cliente { get; set; }
              
        public Produto _Produto { get; set; }

        public decimal TotalPedido { get; set; }

        public IEnumerable<IntercProdutoPedido> _IntercProdutoPedido { get; set; }

        public Preference Preference { get; set; }

    }
}
