using AgendaPro.Application.DTOs.ClienteDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using AgendaPro.Infrastructure.Repositories.Interfaces;
using Mysqlx;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AgendaPro.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IGeralRepo _geralrepo;
        public ClienteService(IGeralRepo geralrepo)
        {
            _geralrepo = geralrepo;
        }
        public async Task<Cliente> AtualizarCliente(int id, AtualizarClienteRequest request)
        {
            var cliente = await _geralrepo.PegarPorId<Cliente>(id);
            if (cliente == null)
            {
                throw new NotImplementedException();
            }
            cliente.telefone = request.telefone;
            cliente.nome = request.nome;
            cliente.email = request.email;

            await _geralrepo.Atualizar<Cliente>(cliente);
            return cliente;
        }

        public async Task<Cliente> CriarCliente(CriarClienteRequest request)
        {
            if(request ==  null)
            {
                throw new NotImplementedException();
            }
            var clientes = await _geralrepo.PegarTodos<Cliente>();
            foreach (Cliente c in clientes)
            {
                //Lançando uma excessao em caso de email que ja existe
                if(c.email == request.email)
                {
                    throw new NotImplementedException();
                }
            }
            var cliente = new Cliente
            {
                nome = request.nome,
                email = request.email,
                ativo = true, //Ativo iniciando true pelo sistema
                telefone = request.telefone,
                dataCadastro = DateTime.Now //Date time do momento da criaçao
            };

            await _geralrepo.Adicionar<Cliente>(cliente);
            return cliente;
        }

        public async Task<Cliente> DeletarCliente(int id)
        {
            var cliente = await _geralrepo.PegarPorId<Cliente>(id);
            if(cliente == null)
            {
                throw new NotImplementedException();
            }

            cliente.ativo = false; //Desativando o cliente, de forma que no front ele pareça deletado
            await _geralrepo.Atualizar<Cliente>(cliente);
            return cliente;
        }

        public async Task<Cliente> PegarClienteId(int id)
        {
            var cliente = await _geralrepo.PegarPorId<Cliente>(id);
            if(cliente == null)
            {
                throw new NotImplementedException();
            }
            return cliente;
        }

        public async Task<List<Cliente>> PegarClientes()
        {
            var clientes = await _geralrepo.PegarTodos<Cliente>();
            if(clientes == null)
            {
                throw new NotImplementedException();
            }

            return clientes;
        }
    }
}
