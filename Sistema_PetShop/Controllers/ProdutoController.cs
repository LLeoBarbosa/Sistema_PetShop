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
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _iprodutoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoController(IProdutoRepository iprodutoRepository, ICategoriaRepository categoriaRepository)
        {
            _iprodutoRepository = iprodutoRepository;
            _categoriaRepository = categoriaRepository;
        }

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult Index(int categoriaId)
        {

            //var produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId);

            ViewData["Produto"] = _categoriaRepository.Categorias.Where(c => c.CategoriaId == categoriaId).First().Nome.ToString();

            ProdutoViewModel produtoViewModel = new ProdutoViewModel
            {
                Produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId),
              

            };

            return View(produtoViewModel);

        }


        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult ObterTodosProdutos()
        {
            return RedirectToAction("Index", "Home");
        }

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult ExibirDetalhesDoProduto(int produtoId)
        {
            var produto = _iprodutoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return View(produto);

        }



    }
}