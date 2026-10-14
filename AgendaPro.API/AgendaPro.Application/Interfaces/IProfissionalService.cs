using AgendaPro.Application.DTOs.ProfissionalDTO;
using AgendaPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Interfaces
{
    public interface IProfissionalService
    {
        public Task<Profissional> CriarProfissional(CriarProfissionalRequest request);
        public Task<Profissional> AtualizarProfissional(int id, AtualizarProfissionalRequest request);
        public Task<Profissional> PegarProfissionalId(int id);
        public Task<List<Profissional>> PegarProfissionals();
        public Task<Profissional> DeletarProfissional(int id);
    }
}
