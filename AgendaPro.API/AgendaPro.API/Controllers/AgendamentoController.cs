using AgendaPro.Application.DTOs.AgendamentoDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoservice;
        public AgendamentoController(IAgendamentoService agendamentoservice)
        {
            _agendamentoservice = agendamentoservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agendamento>>> Get()
        {
            var agendamentos = await _agendamentoservice.PegarAgendamentos();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> Get(int id)
        {
            var agendamento = await _agendamentoservice.PegarAgendamentoId(id);
            return Ok(agendamento);
        }

        [HttpPost]

        public async Task<ActionResult<Agendamento>> Post(CriarAgendamentoRequest request)
        {
            var agendamento = await _agendamentoservice.CriarAgendamento(request);
            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Agendamento>> Put(int id, AtualizarAgendamentoRequest request)
        {
            var agendamento = await _agendamentoservice.AtualizarAgendamento(id, request);
            return Ok(agendamento);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Agendamento>> Patch(int id)
        {
            return Ok(await _agendamentoservice.DeletarAgendamento(id));
        }


    }
}
