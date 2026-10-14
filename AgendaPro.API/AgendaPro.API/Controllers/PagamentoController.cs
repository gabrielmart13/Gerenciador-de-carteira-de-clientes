using AgendaPro.Application.DTOs.PagamentoDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {

        private readonly IPagamentoService _pagamentoservice;
        public PagamentoController(IPagamentoService pagamentooservice)
        {
            _pagamentoservice = pagamentooservice;
        }

        [HttpGet]
        public async Task<ActionResult <List<Pagamento>>> Get()
        {
            var pagamentos = await _pagamentoservice.PegarPagamentos();
            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> Get(int id)
        {
            var pagamento = await _pagamentoservice.PegarPagamentoId(id);
            return Ok(pagamento);
        }

        [HttpPost]
        public async Task<ActionResult<Pagamento>> Post(CriarPagamentoRequest request)
        {
            var pagamento = await _pagamentoservice.CriarPagamento(request);
            return Ok(pagamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pagamento>> Put(int id, AtualizarPagamentoRequest request)
        {
            var pagamento = await _pagamentoservice.AtualizarPagamento(id, request);
            return Ok(pagamento);
        }
    }
}
