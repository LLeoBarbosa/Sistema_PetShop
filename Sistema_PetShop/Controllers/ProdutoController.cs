using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Repositories.Interfaces;

namespace Sistema_PetShop.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _iprodutoRepository;

        public ProdutoController(IProdutoRepository iprodutoRepository, ICategoriaRepository categoriaRepository)
        {
            _iprodutoRepository = iprodutoRepository;
        }

        public IActionResult Index(int categoriaId)
        {

            var produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId);

            if (categoriaId == 34)
            {
                ViewData["Produto"] = "Alimentação";
            }
            if (categoriaId == 35)
            {
                ViewData["Produto"] = "Higiene";
            }
            if (categoriaId == 36)
            {
                ViewData["Produto"] = "Entretenimento";
            }
            if (categoriaId == 37)
            {
                ViewData["Produto"] = "Medicação";
            }
                             

            return View(produtos);
           
        }


        //public IActionResult ExibeProduto(int categoriaId)
        //{

        //    var produtos = _iprodutoRepository.Produtos.Where(p => p.CategoriaId == categoriaId);

        //    return View(produtos);
        //}

    }
}