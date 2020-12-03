using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;

        public UsuarioRepository(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        //**********************************************************************************
        //**********************************************************************************
        public Usuario Login(Usuario usuario)
        {

            Usuario usuarioLogado = _aplicacaoDbContext.Usuarios.Where(u => u.Username == usuario.Username && u.Password == usuario.Password).FirstOrDefault();

            return usuarioLogado;
            //throw new NotImplementedException();
        }

        //**********************************************************************************
        //**********************************************************************************
        public void Logout()
        {
            throw new NotImplementedException();
        }

        //**********************************************************************************
        //**********************************************************************************
        public void RegistrarUsuario(Usuario usuario)
        {
            try
            {
                usuario.Status = "Ativo";
                usuario.Role = "Pessoal";

                _aplicacaoDbContext.Usuarios.Add(usuario);
                _aplicacaoDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                               
            }
        }
    }
}
