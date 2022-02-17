using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimuladorLucroAPI.Models;

namespace SimuladorLucroAPI.Data
{
    public class SimuladorLucroAPIContext : IdentityDbContext<User>
    {
        public SimuladorLucroAPIContext (DbContextOptions<SimuladorLucroAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Servico> Servico { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definições para a tabela de serviços
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

            // Definições para a tabela de agendamentos
            modelBuilder.Entity<Agendamento>()
                .HasOne(p => p.Servico).WithMany();
            modelBuilder.Entity<Agendamento>()
                .Property(p => p.DataHora).IsRequired();
            modelBuilder.Entity<Agendamento>()
                .Property(p => p.Valor).HasColumnType("DECIMAL(5,2)").IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies();

    }
}
