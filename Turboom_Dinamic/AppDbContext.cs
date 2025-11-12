using Microsoft.EntityFrameworkCore;
using System;
using Turboom_Dinamic.Models;

namespace Turboom_Dinamic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Problema> Problemas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}
