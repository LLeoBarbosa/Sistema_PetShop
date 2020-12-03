using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;

namespace Sistema_PetShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AccountController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //**********************************************************************************
        //**********************************************************************************
        public IActionResult Index()
        {
            return View();
        }

        //**********************************************************************************
        //REGISTRO DE USUARIO
        //**********************************************************************************
        public IActionResult Registrar()
        {
            return View();
        }

        //.................................................................................
        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            _usuarioRepository.RegistrarUsuario(usuario);

            ViewBag.Message = "Usuario " + usuario.Username + " cadastrado com êxito!";

            return View("Registrar");
        }
        //**********************************************************************************
        //LOGIN DO USUARIO
        //**********************************************************************************
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //.................................................................................
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            Usuario usuarioLogado = _usuarioRepository.Login(usuario);

            if (usuarioLogado == null)
            {
                ViewBag.Message = "Usuario ou Senha invalido, ou inexistente.";
                return View("Index");
            }

            HttpContext.Session.SetString("usuario", usuarioLogado.Username);

            return RedirectToAction("Index", "Home");
        }
        //**********************************************************************************
        //**********************************************************************************
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }


    }
}