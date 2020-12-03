using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Implementation;
using Sistema_PetShop.Repositories.Interfaces;

namespace Sistema_PetShop.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _iclienteRepository;
        private readonly IPedidoRepository _ipedidoRepository;
        private readonly AplicacaoDbContext _aplicacaoDbContext;
        DateTime date = DateTime.Now;
        string idSessao = "";


        public ClienteController(IClienteRepository iclienteRepository, IPedidoRepository ipedidoRepository, AplicacaoDbContext aplicacaoDbContext)
        {
            _iclienteRepository = iclienteRepository;
            _ipedidoRepository = ipedidoRepository;
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        //*********************************************************************************
        //*********************************************************************************
        public IActionResult Index()
        {
            return View();
        }

        //*********************************************************************************
        //*********************************************************************************
        public IActionResult InserirCliente()
        {
            /*buscar o ultimo id da sessção após arrastar o produto para o carrinho;
            buscar o ultimo id da sessão gravado no pedido
            se forem diferentes: criar o cliente, o pedido e grava o id da sessão atual na pedido.
            se forem iguais: vincula os produtos ao pedido

            */
            idSessao = _aplicacaoDbContext.ItensCarrinhoCompras.Last().CarrinhoCompraId;

            string CarrinhoIdPedido = _ipedidoRepository.Pedidos.Last().CarrinhoCompraId;

            if (string.IsNullOrEmpty(CarrinhoIdPedido) || (CarrinhoIdPedido != idSessao))
            {
                ViewData["data"] = date.ToString("dd/MM/yyyy");

                return View();
            }
            else
            {
                //retorna o pedido qua ja foi criado e passa para o vinculo
                var pedido = _ipedidoRepository.Pedidos.First(p => p.CarrinhoCompraId == idSessao);

                return RedirectToAction("VincularProdutoPedido", "Pedido", pedido);
            }
            
        }

        //*********************************************************************************
        //*********************************************************************************
        [HttpPost]
        public IActionResult GravarCliente(Cliente cliente)
        {

            Cliente _cliente = new Cliente();

            if (ModelState.IsValid)
            {
                _cliente.ClienteId = _iclienteRepository.InserirCliente(cliente);
            }
            else
            {
                ModelState.AddModelError("", "erro ao gravar!");
            }

            return RedirectToAction("CriarPedido", "Pedido", cliente);
        }

    }
}
