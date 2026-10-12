using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.ClienteDTO
{
    public class AtualizarClienteRequest
    {
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public bool ativo { get; set; }
    }
}
