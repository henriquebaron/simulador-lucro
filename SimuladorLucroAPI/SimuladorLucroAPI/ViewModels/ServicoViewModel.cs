using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimuladorLucroAPI.Models;

namespace SimuladorLucroAPI.ViewModels
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Duracao { get; set; }
        public decimal Valor { get; set; }
        public decimal Custo { get; set; }

        public ServicoViewModel() { }

        public ServicoViewModel(Servico model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Descricao = model.Descricao;
            Duracao = model.Duracao.ToString(@"hh\:mm");
            Valor = model.Valor;
            Custo = model.Custo;
        }

    }
}
