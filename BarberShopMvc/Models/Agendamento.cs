using System.ComponentModel.DataAnnotations;

namespace BarberShopMvc.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A {0} são obrigatórias.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataHora { get; set; }
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente {  get; set; }
        [Required(ErrorMessage = "O serviço é obrigatório.")]
        [Display(Name = "Serviço")]
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
