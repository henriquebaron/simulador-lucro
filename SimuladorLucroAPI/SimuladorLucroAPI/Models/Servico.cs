using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimuladorLucroAPI.ViewModels;

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

        public Servico() { }

        public Servico(ServicoViewModel viewModel)
        {
            Id = viewModel.Id;
            Nome = viewModel.Nome;
            Descricao = viewModel.Descricao;
            var partesDuracao = viewModel.Duracao.Split(':');
            Duracao = new TimeSpan(int.Parse(partesDuracao[0]), int.Parse(partesDuracao[1]), 0);
            Valor = viewModel.Valor;
            Custo = viewModel.Custo;
        }
    }
}
