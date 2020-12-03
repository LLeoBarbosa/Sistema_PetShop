using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using Sistema_PetShop.ViewModels;

namespace Sistema_PetShop.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _ipedidoRepository;
        //private readonly IProdutoRepository _iprodutoRepository;
        private readonly CarrinhoCompra _CarrinhoCompra;
        private readonly AplicacaoDbContext _aplicacaoDbContext;
        private readonly IClienteRepository _clienteRepository;
        List<IntercProdutoPedido> Vinculos = new List<IntercProdutoPedido>();

        Pedido pedido = new Pedido();

        string numero, dataVenda, _data;

        public PedidoController(IPedidoRepository ipedidoRepository, IClienteRepository clienteRepository, CarrinhoCompra CarrinhoCompra, AplicacaoDbContext aplicacaoDbContext)
        {
            _ipedidoRepository = ipedidoRepository;
            _CarrinhoCompra = CarrinhoCompra;
            _aplicacaoDbContext = aplicacaoDbContext;
            _clienteRepository = clienteRepository;

        }

        //*********************************************************************************
        //*********************************************************************************

        public IActionResult Index(Pedido pedido)
        {

            PedidoViewModel pedidoViewModel = new PedidoViewModel
            {
                _Cliente = _clienteRepository.obterCliente(pedido.ClienteId),
                _IntercProdutoPedido = _ipedidoRepository.ObterProdutos(pedido),
                TotalPedido = _CarrinhoCompra.ObterCarrinhoCompraTotal()

            };

            //ViewData["resumo"] = "O resumo do pedido sera exebido aqui!";

            numero = pedidoViewModel._IntercProdutoPedido.Last().NumeroPedido.ToString();
            dataVenda = pedidoViewModel._IntercProdutoPedido.Last().DataVenda.ToString();

            //Formatação somete para exibir o numero do pedido
            _data = dataVenda.Substring(0, 10).Replace("/", "");
                
            ViewData["NumeroPedido"] = numero;
            ViewData["DataVenda"] = _data;
            ViewData["_DataVenda"] = dataVenda;
                  
            return View(pedidoViewModel);
        }

        //*********************************************************************************
        //*********************************************************************************

        public IActionResult CriarPedido(Cliente cliente)
        {
            pedido = _ipedidoRepository.CriarPedido(cliente);

            return RedirectToAction("VincularProdutoPedido", "Pedido", pedido);
        }


        //*********************************************************************************
        //*********************************************************************************
        public IActionResult VincularProdutoPedido(Pedido pedido)
        {

            var itensDoCarrinho = _CarrinhoCompra.ObterCarrinhoCompraItens();

            var Vinculos = _aplicacaoDbContext.Produtos_Pedidos.Where(pp => pp.NumeroPedido == pedido.NumeroPedido && pp.DataVenda == pedido.DataVenda).ToList();

            if (Vinculos.Count() == 0)
            {
                foreach (var item in itensDoCarrinho)
                {
                    var _ProdutoPedido = new IntercProdutoPedido
                    {
                        NumeroPedido = pedido.NumeroPedido,
                        DataVenda = pedido.DataVenda,
                        ProdutoId = item.Produto.ProdutoId,
                        Valor = item.Produto.Preco,
                        QTDVendida = item.Quantidade
                    };

                    _aplicacaoDbContext.Produtos_Pedidos.Add(_ProdutoPedido);
                }
            }
            else
            {

                foreach (var item in Vinculos)
                {
                    _aplicacaoDbContext.Set<IntercProdutoPedido>().Remove(item);
                    _aplicacaoDbContext.SaveChanges();
                }

                foreach (var item in itensDoCarrinho)
                {
                    var intercProdutoPedido = new IntercProdutoPedido
                    {
                        NumeroPedido = pedido.NumeroPedido,
                        DataVenda = pedido.DataVenda,
                        ProdutoId = item.Produto.ProdutoId,
                        Valor = item.Produto.Preco,
                        QTDVendida = item.Quantidade
                    };

                    _aplicacaoDbContext.Produtos_Pedidos.Add(intercProdutoPedido);
                }

            }

            _aplicacaoDbContext.SaveChanges();

            return RedirectToAction("Index", "Pedido", pedido);
        }

    }
}