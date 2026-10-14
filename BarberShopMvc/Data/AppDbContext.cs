using BarberShopMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShopMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
