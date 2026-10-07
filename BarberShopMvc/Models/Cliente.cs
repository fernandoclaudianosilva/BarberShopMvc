namespace BarberShopMvc.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NumeroTelefone {  get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }

    }
}
