using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class ServicoQuarto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Horario { get; set; }
        [Required]
        public double ValorServico { get; set; }
        [Required]
        public bool Disponibilidade { get; set; }

    }
}
