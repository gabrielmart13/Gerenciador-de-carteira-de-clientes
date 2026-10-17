using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Infrastructure
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agendamento>().ToTable("agendamento");
            modelBuilder.Entity<Cliente>().ToTable("cliente");
            modelBuilder.Entity<Pagamento>().ToTable("pagamento");
            modelBuilder.Entity<Servico>().ToTable("servico");
            modelBuilder.Entity<Profissional>().ToTable("profissional");

            modelBuilder.Entity<Agendamento>().HasOne(c => c.cliente).WithMany().HasForeignKey(c => c.idCliente);

            modelBuilder.Entity<Agendamento>().HasOne(c => c.servico).WithMany().HasForeignKey(c => c.idServico);

            modelBuilder.Entity<Agendamento>().HasOne(c => c.profissional).WithMany().HasForeignKey(c => c.idProfissional);

            modelBuilder.Entity<Cliente>().HasIndex(e => e.email).IsUnique();

            modelBuilder.Entity<Pagamento>().HasOne(a => a.agendamento).WithMany().HasForeignKey(a => a.idAgendamento);

            modelBuilder.Entity<Servico>().HasIndex(n => n.nome).IsUnique();

            modelBuilder.Entity<Profissional>().HasIndex(e => e.email).IsUnique();
        }
    }
}
