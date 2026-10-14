using AgendaPro.Application.DTOs.ClienteDTO;
using AgendaPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Interfaces
{
    public interface IClienteService
    {
        public Task<Cliente> CriarCliente(CriarClienteRequest request);
        public Task<Cliente> AtualizarCliente(int id, AtualizarClienteRequest request);
        public Task<Cliente> PegarClienteId(int id);
        public Task<List<Cliente>> PegarClientes();
        public Task<Cliente> DeletarCliente(int id);
    }
}
