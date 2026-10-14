using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.AgendamentoDTO
{
    public class AtualizarAgendamentoRequest
    {
        public TimeSpan dataHoraInicio { get; set; }
        public decimal precoAplicado { get; set; }
        public string status { get; set; } = string.Empty;
        public string? observacao { get; set; }
    }
}
