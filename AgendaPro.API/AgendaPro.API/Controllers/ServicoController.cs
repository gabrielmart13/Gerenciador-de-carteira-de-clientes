using AgendaPro.Application.DTOs.ServicoDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoservice;
        public ServicoController(IServicoService servicoservice)
        {
            _servicoservice = servicoservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servico>>> Get()
        {
            var servicos = await _servicoservice.PegarServicos();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> Get(int id)
        {
            var servico = await _servicoservice.PegarServicoId(id);
            return Ok(servico);
        }

        [HttpPost]

        public async Task<ActionResult<Servico>> Post(CriarServicoRequest request)
        {
            var servico = await _servicoservice.CriarServico(request);
            return Ok(servico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Servico>> Put(int id, AtualizarServicoRequest request)
        {
            await _servicoservice.AtualizarServico(id, request);
            return Ok(request);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Servico>> Patch(int id)
        {
            return Ok(await _servicoservice.DeletarServico(id));
        }

    }
}
