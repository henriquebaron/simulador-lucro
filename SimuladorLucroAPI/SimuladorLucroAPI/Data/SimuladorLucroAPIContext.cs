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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>()
                .Property(p => p.Nome).IsRequired();
            modelBuilder.Entity<Servico>()
                .Property(p => p.Descricao).HasColumnType("VARCHAR(300)");
            modelBuilder.Entity<Servico>()
                .Property(p => p.Duracao).HasDefaultValue(new TimeSpan(1, 0, 0));
            modelBuilder.Entity<Servico>()
                .Property(p => p.Valor).HasColumnType("DECIMAL(5,2)").IsRequired();
            modelBuilder.Entity<Servico>()
                .Property(p => p.Custo).HasColumnType("DECIMAL(5,2)").IsRequired();
        }
    }
}
