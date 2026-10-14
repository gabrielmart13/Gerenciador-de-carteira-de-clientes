using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.PagamentoDTO
{
    public class AtualizarPagamentoRequest
    {
        public int idAgendamento { get; set; }
        public DateTime? dataPagamento { get; set; }
        public string metodoPagamento { get; set; } = string.Empty;
        public string status {  get; set; } = string.Empty;
    }
}
