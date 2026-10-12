using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaPro.Domain.Models
{
    public  class Pagamento
    {
        [Key]
        public int idPagamento { get; set; }
        public int idAgendamento {  get; set; }

        [ForeignKey(nameof(idAgendamento))]
        public Agendamento? agendamento { get; set; }
        public decimal valor {  get; set; }
        public DateTime? dataPagamento { get; set; }
        public string metodoPagamento { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
    }
}
