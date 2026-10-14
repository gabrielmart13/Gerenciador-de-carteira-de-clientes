using AgendaPro.Application.DTOs.PagamentoDTO;
using AgendaPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Interfaces
{
    public interface IPagamentoService
    {
        public Task<Pagamento> CriarPagamento(CriarPagamentoRequest request);
        public Task<Pagamento> AtualizarPagamento(int id, AtualizarPagamentoRequest request);
        public Task<Pagamento> PegarPagamentoId(int id);
        public Task<List<Pagamento>> PegarPagamentos();
    }
}
