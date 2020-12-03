using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using Sistema_PetShop.ViewModels;

namespace Sistema_PetShop.Controllers
{
    public class PagSeguroController : Controller
    {
        private readonly IPedidoRepository _ipedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly CarrinhoCompra _CarrinhoCompra;

        public PagSeguroController(IPedidoRepository ipedidoRepository, IClienteRepository clienteRepository, CarrinhoCompra CarrinhoCompra)
        {
            _ipedidoRepository = ipedidoRepository;
            _clienteRepository = clienteRepository;
            _CarrinhoCompra = CarrinhoCompra;

        }

        public IActionResult Index(int clienteId, int numero, string dat)
        {

            var pedido = new Pedido
            {
                NumeroPedido = numero,
                DataVenda = Convert.ToDateTime(dat),
            };

            var resumo = new ResumoViewModel {

                _Cliente = _clienteRepository.obterCliente(clienteId),
                _IntercProdutoPedido = _ipedidoRepository.ObterProdutos(pedido),
                TotalPedido = _CarrinhoCompra.ObterCarrinhoCompraTotal()

            };

            return View(resumo);

        }
    }
}