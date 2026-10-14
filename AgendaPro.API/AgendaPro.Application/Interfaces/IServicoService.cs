using AgendaPro.Application.DTOs.ServicoDTO;
using AgendaPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Interfaces
{
    public interface IServicoService
    {
        public Task<Servico> CriarServico(CriarServicoRequest request);
        public Task<Servico> AtualizarServico(int id, AtualizarServicoRequest request);
        public Task<Servico> PegarServicoId(int id);
        public Task<List<Servico>> PegarServicos();
        public Task<Servico> DeletarServico(int id);
    }
}
