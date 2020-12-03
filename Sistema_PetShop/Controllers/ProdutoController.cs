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

        public IActionResult Index(int? categoriaId, string tipoAnimal)
        {

            if (categoriaId != null)
            {
                ViewData["Produto"] = _categoriaRepository.Categorias.Where(c => c.CategoriaId == categoriaId).First().Nome.ToString();

                ProdutoViewModel produtoViewModel = new ProdutoViewModel
                {
                    Produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId),
                };

                return View(produtoViewModel);
            }

            ProdutoViewModel produtoVModel = new ProdutoViewModel()
            {
                Produtos = _iprodutoRepository.Produtos.Where(p => p.EspAnimal == TempData["tipoAnimal"].ToString()).ToList(),

            };

            //produtoViewModel.Produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId);


            return View(produtoVModel);
        }
        //*******************************************************************************************************
        //*******************************************************************************************************


        //public IActionResult Index(ProdutoViewModel animal)
        //{
        //    //var produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId);               
        //    return View(animal);
        //}


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

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult Buscar(string buscar)
        {

            //Verificar a busca de itens com letra minuscula

            IEnumerable<Produto> produtos;

            if (string.IsNullOrEmpty(buscar))
            {
                produtos = _iprodutoRepository.Produtos.OrderBy(p => p.ProdutoId);
            }
            else
            {
                produtos = _iprodutoRepository.Produtos.Where(p => p.DescricaoCurta.ToLower().Contains(buscar.ToLower()));
            }

            return View("~/Views/Produto/Index.cshtml", new ProdutoViewModel { Produtos = produtos });
        }

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult BuscarItensPorAnimal(string tipoAnimal)
        {

            //ProdutoViewModel produtoViewModel = new ProdutoViewModel()
            //{
            //    Produtos = _iprodutoRepository.Produtos.Where(p => p.EspAnimal == tipoAnimal).ToList(),

            //};

            TempData["tipoAnimal"] = tipoAnimal;

            return RedirectToAction("Index", "Produto", tipoAnimal);
        }


    }
}