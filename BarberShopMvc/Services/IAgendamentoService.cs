using BarberShopMvc.Models;

namespace BarberShopMvc.Services
{
    public interface IAgendamentoService
    {
        List<Agendamento> FindAll();
        void Insert(Agendamento obj);
        Agendamento FindById(int id);
        void Delete(int id);
        void Update(Agendamento obj);
    }
}
