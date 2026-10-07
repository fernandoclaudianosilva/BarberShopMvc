namespace BarberShopMvc.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Agendamento>? Agendamentos { get; set; }

    }
}
