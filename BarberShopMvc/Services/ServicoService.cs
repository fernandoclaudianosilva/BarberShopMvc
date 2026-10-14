using BarberShopMvc.Data;
using BarberShopMvc.Models;
using BarberShopMvc.Services.Excptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BarberShopMvc.Services
{
    public class ServicoService : IServicoService
    {
        private readonly AppDbContext _context;

        public ServicoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Servico> FindAll()
        {
            return _context.Servicos.ToList();
        }

        public void Insert(Servico obj)
        {
            _context.Servicos.Add(obj);
            _context.SaveChanges();
        }
        public Servico FindById(int id)
        {
            var obj = _context.Servicos.FirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                throw new NotFoundException("Serviço não encontrado");
            }
            return obj;
        }
        public void Delete(int id)
        {
            var obj = FindById(id);
            if (obj == null)
            {
                throw new NotFoundException("Serviço não encontrado");
            }
            _context.Servicos.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Servico obj)
        {

            if (!_context.Clientes.Any(x => x.Id != obj.Id))
            {
                throw new NotFoundException("Cliente não cadastrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
    
}
