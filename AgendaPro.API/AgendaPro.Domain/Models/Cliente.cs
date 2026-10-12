using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgendaPro.Domain.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public bool ativo { get; set; }
        public DateTime dataCadastro {  get; set; }

    }
}
