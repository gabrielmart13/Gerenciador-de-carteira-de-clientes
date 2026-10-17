using AgendaPro.Application.Exceptions;
using AgendaPro.Application.DTOs.PagamentoDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using AgendaPro.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IGeralRepo _geralrepo;
        public PagamentoService(IGeralRepo geralrepo)
        {
            _geralrepo = geralrepo;
        }
        public async Task<Pagamento> AtualizarPagamento(int id, AtualizarPagamentoRequest request)
        {
            var pagamento = await _geralrepo.PegarPorId<Pagamento>(id);

            if (request == null)
            {
                throw new ValidationException("os dados para atualizar o pagamento sao nulos");
            }
            if (request.dataPagamento == null)
            {
                throw new ValidationException("a data do pagamento nao pode ser nula");
            }
            var agendamento = await _geralrepo.PegarPorId<Agendamento>(request.idAgendamento);
            if (agendamento == null)
            {
                throw new NotFoundException("o agendamento nao existe");
            }

            pagamento.valor = agendamento.precoAplicado;
            pagamento.dataPagamento = request.dataPagamento;
            pagamento.status = request.status;
            pagamento.metodoPagamento = request.metodoPagamento;
            pagamento.idAgendamento = request.idAgendamento;

            await _geralrepo.Atualizar<Pagamento>(pagamento);
            return pagamento;
        }

        public async Task<Pagamento> CriarPagamento(CriarPagamentoRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("os dados para criar o pagamento sao nulos");
            }
            if (request.dataPagamento == null)
            {
                throw new ValidationException("a data do pagamento nao pode ser nula");
            }
            var agendamento = await _geralrepo.PegarPorId<Agendamento>(request.idAgendamento);
            if (agendamento == null)
            {
                throw new NotFoundException("o agendamento nao existe");
            }
            var pagamento = new Pagamento
            {
                valor = agendamento.precoAplicado,
                idAgendamento = request.idAgendamento,
                metodoPagamento = request.metodoPagamento,
                dataPagamento = request.dataPagamento,
                status = "Pendente"
            };

            await _geralrepo.Adicionar<Pagamento>(pagamento);
            return pagamento;
        }

        public async Task<Pagamento> PegarPagamentoId(int id)
        {
            var pagamento = await _geralrepo.PegarPorId<Pagamento>(id);
            if (pagamento == null)
            {
                throw new NotFoundException("o pagamento nao existe");
            }
            return pagamento;
        }

        public async Task<List<Pagamento>> PegarPagamentos()
        {
            var pagamentos = await _geralrepo.PegarTodos<Pagamento>();
            if (pagamentos == null)
            {
                throw new NotFoundException("nenhum pagamento encontrado");
            }
            return pagamentos;
        }
    }
}