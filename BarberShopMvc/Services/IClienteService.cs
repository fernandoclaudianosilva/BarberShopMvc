using BarberShopMvc.Models;

namespace BarberShopMvc.Services

{
    public interface IClienteService
    {
        IEnumerable<Cliente> FindAll();
        void Insert(Cliente obj);
        Cliente FindById(int id);
        void Delete(int id);
        void Update(Cliente obj);
    }
}
