using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> Pedidos { get; }

        Pedido CriarPedido(Cliente cliente);

        IEnumerable<IntercProdutoPedido> ProdutoPedidos { get; }

        IEnumerable<IntercProdutoPedido> ObterProdutos(Pedido pedido);

    }
}
