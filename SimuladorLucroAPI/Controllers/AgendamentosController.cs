using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladorLucroAPI.Data;
using SimuladorLucroAPI.Models;

namespace SimuladorLucroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly SimuladorLucroAPIContext _context;

        public AgendamentosController(SimuladorLucroAPIContext context)
        {
            _context = context;
        }

        // GET: api/Agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamento()
        {
            return await _context.Agendamento.ToListAsync();
        }

        // GET: api/Agendamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return agendamento;
        }

        // PUT: api/Agendamentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(agendamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agendamentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
        {
            _context.Agendamento.Add(agendamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendamento", new { id = agendamento.Id }, agendamento);
        }

        // DELETE: api/Agendamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agendamento>> DeleteAgendamento(int id)
        {
            var agendamento = await _context.Agendamento.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamento.Remove(agendamento);
            await _context.SaveChangesAsync();

            return agendamento;
        }

        private bool AgendamentoExists(int id)
        {
            return _context.Agendamento.Any(e => e.Id == id);
        }
    }
}
