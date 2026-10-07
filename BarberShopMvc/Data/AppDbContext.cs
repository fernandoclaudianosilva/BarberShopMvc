using BarberShopMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShopMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Agendamento> Agendamentos { get; set; }
        DbSet<Servico> Servicos { get; set; }
        DbSet<Cliente> Clientes { get; set; }
    }
}
