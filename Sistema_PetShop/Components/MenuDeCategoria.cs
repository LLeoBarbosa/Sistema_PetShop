using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Components
{
    public class MenuDeCategoria : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public MenuDeCategoria(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {

            var categorias = _categoriaRepository.Categorias.OrderBy(c => c.Nome);

            return View(categorias);

        }

    }
}
