using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShopMvc.Models
{
    public class Servico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [StringLength(100,MinimumLength =3,ErrorMessage = "O nome do {0} deve ter entre {1} e {2} caracteres.")]
        [Display(Name ="Serviço")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0.01, 10000.00, ErrorMessage = "O {0} deve ser superior a zero.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        public ICollection<Agendamento>? Agendamentos { get; set; }

    }
}
