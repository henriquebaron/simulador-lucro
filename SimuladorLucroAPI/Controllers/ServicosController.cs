using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladorLucroAPI.Data;
using SimuladorLucroAPI.Models;
using SimuladorLucroAPI.ViewModels;

namespace SimuladorLucroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly SimuladorLucroAPIContext _context;

        public ServicosController(SimuladorLucroAPIContext context)
        {
            _context = context;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoViewModel>>> GetServico()
        {
            return await _context.Servico.Select(s => new ServicoViewModel(s)).ToListAsync();
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoViewModel>> GetServico(int id)
        {
            var servico = await _context.Servico.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return new ServicoViewModel(servico);
        }

        // PUT: api/Servicos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.Id)
            {
                return BadRequest();
            }

            Servico servico = new Servico(servicoViewModel);

            _context.Entry(servico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicoExists(id))
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

        // POST: api/Servicos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServicoViewModel>> PostServico(ServicoViewModel servicoViewModel)
        {
            Servico servico = new Servico(servicoViewModel);
            _context.Servico.Add(servico);
            await _context.SaveChangesAsync();

            servicoViewModel.Id = servico.Id;
            return CreatedAtAction("GetServico", new { id = servico.Id }, servicoViewModel);
        }

        // DELETE: api/Servicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoViewModel>> DeleteServico(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servico.Remove(servico);
            await _context.SaveChangesAsync();

            return new ServicoViewModel(servico);
        }

        private bool ServicoExists(int id)
        {
            return _context.Servico.Any(e => e.Id == id);
        }
    }
}
