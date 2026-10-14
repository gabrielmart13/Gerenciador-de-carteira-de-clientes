using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.DTOs.AgendamentoDTO
{
    public class CriarAgendamentoRequest
    {
        public int idCliente {  get; set; }
        public int idProfissional {  get; set; }
        public int idServico {  get; set; }
        public TimeSpan dataHoraInicio {  get; set; }
        public decimal precoAplicado {  get; set; }
        public string? observacao {  get; set; }
    }
}
