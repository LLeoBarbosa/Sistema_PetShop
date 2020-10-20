using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Models;
using Sistema_PetShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Components
{
    public class ResumoCarrinhoCompra : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public ResumoCarrinhoCompra(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************

        public IViewComponentResult Invoke()
        {

            var itensDoCarrinho = _carrinhoCompra.ObterCarrinhoCompraItens();
            _carrinhoCompra.ItensCarrinhoCompras = itensDoCarrinho;

            CarrinhoCompraViewModel carrinhoCompraViewModel = new CarrinhoCompraViewModel
            {
                carrinhoCompra = _carrinhoCompra,
                TotalCarrinho = _carrinhoCompra.ObterCarrinhoCompraTotal()
            };

            return View(carrinhoCompraViewModel);

        }
    }
}
