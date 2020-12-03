using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Repositories.Implementation
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicacaoDbContext _aplicacaoDbContext;



        public ClienteRepository(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        public int InserirCliente(Cliente cliente)
        {
            _aplicacaoDbContext.Clientes.Add(cliente);

            _aplicacaoDbContext.SaveChanges();

            return cliente.ClienteId;

        }

        public Cliente obterCliente(int id)
        {
            return _aplicacaoDbContext.Clientes.FirstOrDefault(c => c.ClienteId == id);
        }

        public int ObterId()
        {
           var cliente = _aplicacaoDbContext.Clientes.Last();

            return cliente.ClienteId;
        }
    }
}
