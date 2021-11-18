﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimuladorLucroAPI.Data;

namespace SimuladorLucroAPI.Migrations
{
    [DbContext(typeof(SimuladorLucroAPIContext))]
    partial class SimuladorLucroAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimuladorLucroAPI.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Custo")
                        .HasColumnType("DECIMAL(5,2)");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<TimeSpan>("Duracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasDefaultValue(new TimeSpan(0, 1, 0, 0, 0));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });
#pragma warning restore 612, 618
        }
    }
}
