using AgendaPro.Application.DTOs.ClienteDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Services;
using AgendaPro.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteservice;
        public ClienteController(IClienteService clienteservice) 
        {
            _clienteservice = clienteservice;
        }

        [HttpGet]
        //O actionResult faz com que nosso controller possa retornar nao so um objeto mas tmb uma resposta http
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            var clientes = await _clienteservice.PegarClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _clienteservice.PegarClienteId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(CriarClienteRequest request)
        {
            var cliente = await _clienteservice.CriarCliente(request);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Put(int id, AtualizarClienteRequest request)
        {
            var cliente = await _clienteservice.AtualizarCliente(id, request);
            return Ok(cliente);
        }


    }
}
