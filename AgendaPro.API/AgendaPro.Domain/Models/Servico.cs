using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgendaPro.Domain.Models
{
    public class Servico
    {
        [Key]
        public int idServico { get; set; }
        public string nome {  get; set; } = string.Empty;
        public string? descricao { get; set; } 
        public TimeSpan duracaoMinutos { get; set;  }
        public decimal preco {  get; set; }
        public bool ativo {  get; set; }
    }
}
