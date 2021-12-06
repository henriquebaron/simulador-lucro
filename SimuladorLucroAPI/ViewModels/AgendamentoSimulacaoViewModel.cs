using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.ViewModels
{
    /// <summary>
    /// Classe ViewModel que corresponde à classe <see cref="Models.AgendamentoBase"/> e
    /// representa um agendamento de serviço para simulações, contendo menos propriedades do que
    /// um agendamento completo da classe <see cref="Models.Agendamento"/>.
    /// </summary>
    public class AgendamentoSimulacaoViewModel
    {
        public string Hora { get; set; }
        public int ServicoId { get; set; }
    }
}
