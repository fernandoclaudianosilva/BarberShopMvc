using BarberShopMvc.Models;

namespace BarberShopMvc.Services
{
    public interface IServicoService
    {
        List<Servico> FindAll();
        void Insert(Servico obj);
        Servico FindById(int id);
        void Delete(int id);
        void Update(Servico obj);
    }
}
