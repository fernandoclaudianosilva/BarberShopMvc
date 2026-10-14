namespace BarberShopMvc.Models.ViewModels
{
    public class AgendamentoFormViewModel
    {
        public Agendamento Agendamento { get; set; }
        public List<Cliente> Clientes { get; set; }
        public ICollection<Servico> Servicos { get; set; }
    }
}
