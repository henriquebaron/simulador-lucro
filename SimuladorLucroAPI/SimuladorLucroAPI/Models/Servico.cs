using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Duracao { get; set; }
        public decimal Valor { get; set; }
        public decimal Custo { get; set; }
    }
}
