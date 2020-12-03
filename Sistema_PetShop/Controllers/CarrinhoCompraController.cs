using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using Sistema_PetShop.ViewModels;

namespace Sistema_PetShop.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoCompra carrinhoCompra)
        {
            _produtoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************
        //Exibe os itens adicionados no carrinho
        public IActionResult Index()
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

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************

        public RedirectToActionResult AdicionarItemNoCarrinho(int produtoId)
        {
            var produtoSelecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarItemAoCarrinho(produtoSelecionado, 1);
            }

            return RedirectToAction("Index");

        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************

        public IActionResult RemoverItemDoCarrinho(int ProdutoId)
        {

            var removerProduto = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);

            if (removerProduto != null)
            {
                _carrinhoCompra.RemoverItemDoCarrinho(removerProduto);
            }
            
            return RedirectToAction("Index");
        }
    }
}