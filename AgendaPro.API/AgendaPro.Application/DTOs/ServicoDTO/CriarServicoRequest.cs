using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.ServicoDTO
{
    public class CriarServicoRequest
    {
        public string nome { get; set; } = string.Empty;
        public string? descricao { get; set; }
        public int duracaoMinutos { get; set; }
        public decimal preco { get; set; }
    }
}
