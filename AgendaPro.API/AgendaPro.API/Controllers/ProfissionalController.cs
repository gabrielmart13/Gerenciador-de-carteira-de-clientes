using AgendaPro.Application.DTOs.ProfissionalDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _profissionalservice;
        public ProfissionalController(IProfissionalService profissionalservice)
        {
            _profissionalservice = profissionalservice;
        }

        [HttpGet]
        public async Task<ActionResult <List<Profissional>>> Get()
        {
            var profissionais = await _profissionalservice.PegarProfissionals();
            return Ok(profissionais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profissional>> Get(int id)
        {
            var profissional = await _profissionalservice.PegarProfissionalId(id);
            return Ok(profissional);
        }

        [HttpPost]

        public async Task<ActionResult<Profissional>> Post(CriarProfissionalRequest request)
        {
            var servico = await _profissionalservice.CriarProfissional(request);
            return Ok(servico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profissional>> Put(int id, AtualizarProfissionalRequest request)
        {
            await _profissionalservice.AtualizarProfissional(id, request);
            return Ok(request);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Profissional>> Patch(int id)
        {
            return Ok(await _profissionalservice.DeletarProfissional(id));
        }

    }
}
