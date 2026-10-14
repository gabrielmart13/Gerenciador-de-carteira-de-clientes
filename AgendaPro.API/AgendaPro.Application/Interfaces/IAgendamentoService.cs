using AgendaPro.Application.DTOs.AgendamentoDTO;
using AgendaPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Interfaces
{
    public interface IAgendamentoService
    {        
        public Task<Agendamento> CriarAgendamento(CriarAgendamentoRequest request);
        public Task<Agendamento> AtualizarAgendamento(int id,AtualizarAgendamentoRequest request);
        public Task<Agendamento> PegarAgendamentoId(int id);
        public Task <List<Agendamento>> PegarAgendamentos();
        public Task<Agendamento> DeletarAgendamento(int id);
    }
}
