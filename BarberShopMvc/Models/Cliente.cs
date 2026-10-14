using System.ComponentModel.DataAnnotations;

namespace BarberShopMvc.Models
{
    public class Cliente
    {   
        
        public int Id { get; set; }
        [Required(ErrorMessage = " O campo nome é obrigatorio")]
        [StringLength(100,MinimumLength =3 ,ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O campo Número de Telefone é obrigatório.")]
        [Display(Name = "Numero de Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string? NumeroTelefone {  get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    }
}
