using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra carrinhoCompra { get; set; }
                
        public decimal TotalCarrinho { get; set; }
    }
}
