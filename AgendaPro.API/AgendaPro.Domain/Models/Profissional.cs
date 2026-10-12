using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgendaPro.Domain.Models
{
    public class Profissional
    {
        [Key]
        public int idProfissional {  get; set; } 
        public string nome { get; set; } = string.Empty;
        public string? email { get; set; }
        public string? telefone { get; set; }
        public bool ativo { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFinal {  get; set; }
        
    }
}
