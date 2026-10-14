using BarberShopMvc.Data;
using BarberShopMvc.Models;
using BarberShopMvc.Services.Excptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;



namespace BarberShopMvc.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente>FindAll()
        {
            return _context.Clientes.ToList();
        }
        public void Insert(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Cliente FindById(int id)
        {
            var obj = _context.Clientes.FirstOrDefault(obj => obj.Id == id);
            if (obj == null)
            {
                throw new NotFoundException("Serviço não encontrado");
            }
            return obj;
        }

        public void Update(Cliente obj)
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
        public void Delete(int id)
        {
            var obj = FindById(id);
            if (obj == null)
            {
                throw new NotFoundException("Cliente não encontrado");
            }
                _context.Remove(obj);
                _context.SaveChanges();
            
        }
    }
}
