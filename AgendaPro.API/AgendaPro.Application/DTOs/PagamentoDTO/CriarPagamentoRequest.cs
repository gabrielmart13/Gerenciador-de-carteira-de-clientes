using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.PagamentoDTO
{
    public class CriarPagamentoRequest
    {
        public int idAgendamento {  get; set; }
        public decimal valor {  get; set; }
        public DateTime? dataPagamento {  get; set; }
        public string metodoPagamento {  get; set; } = string.Empty;

    }
}
