using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Models;

namespace Sistema_PetShop.Controllers
{
    public class StatusController : Controller
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public StatusController(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }


        public IActionResult Index()
        {
                        
            _carrinhoCompra.LimparCarrinho();      

            return View();

        }
    }
}