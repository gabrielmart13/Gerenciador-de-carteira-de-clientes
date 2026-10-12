using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgendaPro.Application.DTOs.ProfissionalDTO
{
    public class CriarProfissionalRequest
    {
        public string nome {  get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone {  get; set; } = string.Empty;
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFim { get; set; }
    }
}
