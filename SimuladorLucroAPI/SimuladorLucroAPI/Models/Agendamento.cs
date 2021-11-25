using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }

        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
