using Microsoft.EntityFrameworkCore;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Implementation
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        DateTime date = DateTime.Now;

        //*************************************************************************
        //*************************************************************************

        public PedidoRepository(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        //*************************************************************************
        //*************************************************************************
        public IEnumerable<Pedido> Pedidos => _aplicacaoDbContext.Pedidos.ToList();

        //public IEnumerable<IntercProdutoPedido> ProdutoPedidos => _aplicacaoDbContext.Produtos_Pedidos.ToList();
        public IEnumerable<IntercProdutoPedido> ProdutoPedidos => _aplicacaoDbContext.Produtos_Pedidos.Include(p => p.Produto).ToList();


        //*************************************************************************
        //*************************************************************************
      
        public Pedido CriarPedido(Cliente _cliente)
        {

            var pedidos = _aplicacaoDbContext.Pedidos.ToList();

            var data = Convert.ToDateTime(date.ToString("dd/MM/yyyy"));
                  
            //var cliente = _aplicacaoDbContext.Clientes.Where(c => c.ClienteId == id);
            Pedido pedido = new Pedido();

            if (pedidos.Count() == 0)
            {
                pedido.NumeroPedido = 1;
                pedido.DataVenda = data;
                pedido.ClienteId = _cliente.ClienteId;
                pedido.Detalhes = "Obs.";
                //pedido.CarrinhoCompraId = 

                _aplicacaoDbContext.Pedidos.Add(pedido);
            }
            else
            {
                pedido.NumeroPedido = pedidos.Last().NumeroPedido + 1;
                pedido.DataVenda = data;
                pedido.ClienteId = _cliente.ClienteId;
                pedido.Detalhes = "Obs.";
                pedido.CarrinhoCompraId = _aplicacaoDbContext.ItensCarrinhoCompras.Last().CarrinhoCompraId;

                _aplicacaoDbContext.Pedidos.Add(pedido);
            }

            _aplicacaoDbContext.SaveChanges();

            return pedido;
        }

        public IEnumerable<IntercProdutoPedido> ObterProdutos(Pedido pedido)
        {
            return _aplicacaoDbContext.Produtos_Pedidos.Include(p => p.Produto).Where(pp => pp.NumeroPedido == pedido.NumeroPedido && pp.DataVenda == pedido.DataVenda).ToList();
        }
    }

          
}

