using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Repositories.Interfaces;
using Sistema_PetShop.ViewModels;

namespace Sistema_PetShop.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        //*******************************************************************************************************
        //*******************************************************************************************************

        public IActionResult Index()
        {

            //var Categoria = _categoriaRepository.Categorias;
            //ViewData["Categorias"] = "Categorias";
            //return View(Categoria);


            CategoriaViewModel catergoriasViewModel = new CategoriaViewModel
            {
                Categoria = _categoriaRepository.Categorias,
                CategoriaAtual = "Categorias"
            };

            return View(catergoriasViewModel);
        }
    }
}