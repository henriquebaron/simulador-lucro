using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimuladorLucroAPI.Models;
using SimuladorLucroAPI.ViewModels;
using SimuladorLucroAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorLucroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacaoController : ControllerBase
    {
        private readonly SimuladorLucroAPIContext _context;

        public SimulacaoController(SimuladorLucroAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public AgendamentoSimulacaoViewModel[] GerarExemplos()
        {
            AgendamentoSimulacaoViewModel[] resultado = new AgendamentoSimulacaoViewModel[3];
            resultado[0] = new AgendamentoSimulacaoViewModel() { Hora = "08:30", ServicoId = 1 };
            resultado[1] = new AgendamentoSimulacaoViewModel() { Hora = "10:30", ServicoId = 2 };
            resultado[2] = new AgendamentoSimulacaoViewModel() { Hora = "13:00", ServicoId = 1 };
            return resultado;
        }

        [HttpGet]
        [Route("simfaturamento")]
        public decimal CalcularFaturamento(AgendamentoSimulacaoViewModel[] agendamentos)
        {
            IEnumerable<AgendamentoBase> listaAgendamentos = agendamentos.ToList()
                .Select(p => new AgendamentoBase()
                {
                    DataHora = DateTime.Parse(p.Hora),
                    ServicoId = p.ServicoId,
                    Servico = _context.Servico.Where(s => s.Id == p.ServicoId).Single()
                });
            return AgendamentoBase.CalcularFaturamento(listaAgendamentos);
        }
    }
}
