using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using Sistema_PetShop.ViewModels;

namespace Sistema_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        //private readonly IClienteRepository _clienteRepository;
        //private readonly IPedidoRepository _pedidoRepository;
        //private readonly IProdutoRepository _produtoRepository;
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        public PayPalController(AplicacaoDbContext aplicacaoDbContext)
        {
           // _clienteRepository = clienteRepository;
           // _pedidoRepository = pedidoRepository;
           // _produtoRepository = produtoRepository;
            _aplicacaoDbContext = aplicacaoDbContext;

        }

        public void PagPayPal(int numpedido, string datavenda)
        {

            DateTime data = Convert.ToDateTime(string.Format("{0:d/M/yyyy}", datavenda));

            var produto = _aplicacaoDbContext.Produtos_Pedidos.Include(p => p.Produto).Where(pp => pp.NumeroPedido == numpedido && pp.DataVenda == data && pp.ProdutoId == pp.Produto.ProdutoId).ToList();

            string url = @"https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_cart";

            string dados = "";

            dados = dados + "&business=sb-itbl-business@business.com&";

            for (int i = 0; i < produto.Count; i++)
            {
                dados = dados + "item_number_" + (i + 1) + "=" + produto[i].Produto.ProdutoId + "&";

                dados = dados + "item_name_" + (i + 1) + "=" + produto[i].Produto.DescricaoCurta + "&";

                dados = dados + "quantity_" + (i + 1) + "=" + produto[i].Produto.ItensProdutoPedidos.Last().QTDVendida + "&";

                dados = dados + "amount_" + (i + 1) + "=" + produto[i].Produto.ItensProdutoPedidos.Last().Valor.ToString().Replace(",", ".") + "&";
            }

            dados = dados + "currency_code=BRL&";
            dados = dados + "return=https://localhost:44358/status/index&";

            #region
            //dados = dados + "first_name=Leonardo&";
            //dados = dados + "last_name=Barbosa&";
            //dados = dados + "address1=Rua da Salvacao 3000&";
            //dados = dados + "address2=Paiol&";
            //dados = dados + "city=Nilopolis&";
            //dados = dados + "state=Rio de Janeiro&";
            //dados = dados + "zip=26545&";
            //dados = dados + "charset=UTF-8&";
            //dados = dados + "address_override=1";
            //dados = dados + "Return=0";

            //string dados = "&amount=1.99&";
            //dados = dados + "business=sb-itbl-business@business.com&";
            //dados = dados + "item_name=paçoquita&";
            //dados = dados + "currency_code=BRL&";
            //dados = dados + "quantity=1&";
            //dados = dados + "first_name=Leonardo&";
            //dados = dados + "last_name=Barbosa&";
            //dados = dados + "address1=Rua da Salvacao&";
            //dados = dados + "address2=3000&";
            //dados = dados + "city=Nilopolis&";
            //dados = dados + "state=Rio de Janeiro&";
            //dados = dados + "zip=26545&";
            //dados = dados + "address_override=0&";
            #endregion

            dados = dados + "charset=UTF-8&";
            dados = dados + "upload=1";
            

            string newUrl = url + dados;

            Response.Redirect(newUrl);

        }


    }
}