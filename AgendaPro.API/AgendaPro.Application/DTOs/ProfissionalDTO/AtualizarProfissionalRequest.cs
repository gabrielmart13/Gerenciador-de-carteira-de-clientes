using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.ProfissionalDTO
{
    public class AtualizarProfissionalRequest
    {
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public bool ativo { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFim { get; set; }
    }
}
