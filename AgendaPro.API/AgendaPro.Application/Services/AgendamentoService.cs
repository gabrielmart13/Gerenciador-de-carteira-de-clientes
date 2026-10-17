using AgendaPro.Application.Exceptions;
using AgendaPro.Application.DTOs.AgendamentoDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using AgendaPro.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IGeralRepo _geralrepo;
        public AgendamentoService(IGeralRepo geralrepo)
        {
            _geralrepo = geralrepo;
        }
        public async Task<Agendamento> AtualizarAgendamento(int id, AtualizarAgendamentoRequest request)
        {


            var agendamentos = await _geralrepo.PegarTodos<Agendamento>();

            var agendamento = await _geralrepo.PegarPorId<Agendamento>(id);

            var servico = await _geralrepo.PegarPorId<Servico>(agendamento.idServico);
            var duracao = request.dataHoraInicio + servico.duracaoMinutos;

            var profissional = await _geralrepo.PegarPorId<Profissional>(agendamento.idProfissional);

            if (request == null)
            {
                throw new NotFoundException("os dados para atualizar sao nulos");
            }
            if (request.dataHoraInicio <= TimeSpan.Zero)
            {
                throw new ValidationException("O horario de inicio não pode ser menor que 0");
            }
            if (duracao > profissional.horaFinal)
            {
                throw new ValidationException("O agendamento não pode acabar apos o horario de trabalho do funcionario");
            }

            foreach (Agendamento a in agendamentos)
            {
                if (a.idProfissional == agendamento.idProfissional)
                {
                    if (a.status != "Cancelado" && a.idAgendamento != agendamento.idAgendamento)
                    {
                        if (a.dataHoraFim > request.dataHoraInicio && a.dataHoraInicio < duracao)
                        {
                            throw new ConflictException("O profissional não pode ter 2 agendamentos no mesmo horario");
                        }
                    }

                }
            }
            agendamento.dataHoraInicio = request.dataHoraInicio;
            agendamento.observacao = request.observacao;
            agendamento.precoAplicado = request.precoAplicado;
            agendamento.status = request.status;
            agendamento.dataHoraFim = duracao;

            await _geralrepo.Atualizar<Agendamento>(agendamento);
            return agendamento;
        }

        public async Task<Agendamento> CriarAgendamento(CriarAgendamentoRequest request)
        {

            var agendamentos = await _geralrepo.PegarTodos<Agendamento>();

            var servico = await _geralrepo.PegarPorId<Servico>(request.idServico);
            var profissional = await _geralrepo.PegarPorId<Profissional>(request.idProfissional);
            var duracao = request.dataHoraInicio + servico.duracaoMinutos;

            if(request == null)
            {
                throw new NotFoundException("os dados para atualizar sao nulos");
            }
            if (request.dataHoraInicio <= TimeSpan.Zero)
            {
                throw new ValidationException("O horario de inicio não pode ser menor que 0");
            }
            if(duracao > profissional.horaFinal)
            {
                throw new ValidationException("O agendamento não pode acabar apos o horario de trabalho do funcionario");
            }
            foreach (Agendamento a in agendamentos)
            {
                if(a.idProfissional == request.idProfissional)
                {
                    if(a.dataHoraFim > request.dataHoraInicio && a.dataHoraInicio < duracao)
                    {
                        throw new ConflictException("O profissional não pode ter 2 agendamentos no mesmo horario");
                    }
                }
            }

            var agendamento = new Agendamento
            {
                idCliente = request.idCliente,
                idServico = request.idServico,
                idProfissional = request.idProfissional,
                dataHoraInicio = request.dataHoraInicio,
                precoAplicado = request.precoAplicado,
                observacao = request.observacao,
                dataCriacao = DateTime.Now,
                dataHoraFim = duracao,
                status = "Pendente"
            };

            await _geralrepo.Adicionar<Agendamento>(agendamento);
            return agendamento;
            
        }

        public async Task<Agendamento> DeletarAgendamento(int id)
        {
            var agendamento = await _geralrepo.PegarPorId<Agendamento>(id);
            if (agendamento == null)
            {
                throw new NotFoundException("o agendamento nao existe");
            }

            agendamento.status = "Cancelado";

            await _geralrepo.Atualizar<Agendamento>(agendamento);
            return agendamento;
        }

        public async Task<Agendamento> PegarAgendamentoId(int id)
        {
            var agendamento = await _geralrepo.PegarPorId<Agendamento>(id);
            if(agendamento == null)
            {
                throw new NotFoundException("o agendamento nao existe");
            }

            return agendamento;
        }

        public async Task<List<Agendamento>> PegarAgendamentos()
        {
            var agendamentos = await _geralrepo.PegarTodos<Agendamento>();
            if(agendamentos == null)
            {
                throw new NotFoundException("o agendamento nao existe");
            }

            return agendamentos;
        }
    }
}
