using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using Sistema_PetShop.ViewModels;

namespace Sistema_PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _iprodutoRepository;

        public HomeController(IProdutoRepository iprodutoRepository)
        {
            _iprodutoRepository = iprodutoRepository;
        }

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult Index()
        {

            ViewData["Produto"] = "Aqui sera exibido todos os produtos";

            ProdutoViewModel produtoViewModel = new ProdutoViewModel
            {
                Produtos = _iprodutoRepository.Produtos
            };

            return View(produtoViewModel);
        }

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult Privacy()
        {
            return View();
        }


        //*******************************************************************************************************
        //*******************************************************************************************************
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
