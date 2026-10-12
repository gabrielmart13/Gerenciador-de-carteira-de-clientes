using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgendaPro.Domain.Models
{
    public class Agendamento
    {
        [Key]
        public int idAgendamento {  get; set; }
        public int idCliente {  get; set; }
        [ForeignKey(nameof(idCliente))]
        public Cliente? cliente {  get; set; }
        public int idProfissional {  get; set; }

        [ForeignKey(nameof(idProfissional))]
        public Profissional? profissional { get; set; }
        public int idServico {  get; set; }

        [ForeignKey(nameof(idServico))]
        public Servico? servico { get; set; }
        public TimeSpan dataHoraInicio {  get; set; }
        public TimeSpan dataHoraFim {  get; set; }
        public decimal precoAplicado {  get; set; }
        public string status {  get; set; } = string.Empty;
        public string? observacao {  get; set; } 
        public DateTime dataCriacao {  get; set; }
    }
}
