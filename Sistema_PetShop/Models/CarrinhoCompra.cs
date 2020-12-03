using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sistema_PetShop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class CarrinhoCompra

    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        public string CarrinhoCompraId { get; set; }

        public List<ItensCarrinhoCompra> ItensCarrinhoCompras { get; set; }

        public CarrinhoCompra()
        {

        }

        public CarrinhoCompra(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }
        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************
        //Criando a sessão
        public static CarrinhoCompra ObterCarrinho(IServiceProvider services)
        {
           
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
                       
            var DbContext = services.GetService<AplicacaoDbContext>();
                       
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
                        
            session.SetString("CarrinhoId", carrinhoId);
                        
            return new CarrinhoCompra(DbContext)
            {
                CarrinhoCompraId = carrinhoId
            };

        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************
        public void AdicionarItemAoCarrinho(Produto produto, int quantidade)
        {
           
            var carrinhoCompraItem = _aplicacaoDbContext.ItensCarrinhoCompras.SingleOrDefault(icc => icc.Produto.ProdutoId == produto.ProdutoId && icc.CarrinhoCompraId == CarrinhoCompraId);
                       
            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new ItensCarrinhoCompra
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produto = produto,
                    Quantidade = 1
                };

                _aplicacaoDbContext.ItensCarrinhoCompras.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _aplicacaoDbContext.SaveChanges();

        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************
        public int RemoverItemDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _aplicacaoDbContext.ItensCarrinhoCompras.SingleOrDefault(icc => icc.Produto.ProdutoId == produto.ProdutoId && icc.CarrinhoCompraId == CarrinhoCompraId);

            var qtdLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    qtdLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _aplicacaoDbContext.ItensCarrinhoCompras.Remove(carrinhoCompraItem);
                }
            }

            _aplicacaoDbContext.SaveChanges();

            return qtdLocal;
        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************

        public List<ItensCarrinhoCompra> ObterCarrinhoCompraItens()
        {
            return ItensCarrinhoCompras ?? (ItensCarrinhoCompras = _aplicacaoDbContext.ItensCarrinhoCompras.Where(icc => icc.CarrinhoCompraId == CarrinhoCompraId).Include(icc => icc.Produto).ToList());
        }


        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************
        public void LimparCarrinho()
        {
            var carrinhoItens = _aplicacaoDbContext.ItensCarrinhoCompras.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _aplicacaoDbContext.ItensCarrinhoCompras.RemoveRange(carrinhoItens);

            _aplicacaoDbContext.SaveChanges();
        }

        //***********************************************************************************************************************************************************
        //***********************************************************************************************************************************************************

        public decimal ObterCarrinhoCompraTotal()
        {
            var total = _aplicacaoDbContext.ItensCarrinhoCompras.Where(icc => icc.CarrinhoCompraId == CarrinhoCompraId).Select(icc => icc.Produto.Preco * icc.Quantidade).Sum();

            return total;
        }

    }
}
