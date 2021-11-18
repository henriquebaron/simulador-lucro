using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimuladorLucroAPI.Models;

namespace SimuladorLucroAPI.Data
{
    public class SimuladorLucroAPIContext : DbContext
    {
        public SimuladorLucroAPIContext (DbContextOptions<SimuladorLucroAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SimuladorLucroAPI.Models.Servico> Servico { get; set; }
    }
}
