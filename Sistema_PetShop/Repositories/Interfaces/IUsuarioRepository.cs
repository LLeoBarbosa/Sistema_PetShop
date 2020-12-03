using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        void RegistrarUsuario(Usuario usuario);

        Usuario Login(Usuario usuario);

        void Logout();

    }
}
