using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Models
{
    public class AgendamentoBase
    {
        public DateTime DataHora { get; set; }
        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }

        public static decimal CalcularFaturamento(IEnumerable<AgendamentoBase> agendamentos)
        {
            return agendamentos.Sum(p => p.Servico.Valor);
        }
    }
}
