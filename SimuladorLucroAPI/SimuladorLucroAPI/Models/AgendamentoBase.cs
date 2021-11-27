using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Models
{
    public class AgendamentoBase
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
