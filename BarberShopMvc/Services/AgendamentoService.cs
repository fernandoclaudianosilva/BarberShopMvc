using BarberShopMvc.Data;
using BarberShopMvc.Models;
using BarberShopMvc.Services.Excptions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BarberShopMvc.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly AppDbContext _context;

        public AgendamentoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Agendamento> FindAll()
        {
            return _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .ToList();
        }
        public void Insert(Agendamento obj)
        {
            _context.Agendamentos.Add(obj);
            _context.SaveChanges();
        }

        public Agendamento FindById(int id)
        {
            var obj = _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .FirstOrDefault(x => x.Id == id);
            if(obj == null)
            {
                throw new NotFoundException("Agendamento não encontrado");
            }
            return obj;
        }
        public void Delete(int id)
        {
            var obj = FindById(id);
        }
        public void Update(Agendamento obj)
        {
            
        }
    }   
}
