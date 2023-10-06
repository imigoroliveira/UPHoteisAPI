using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Cnpj { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Endereco { get; set; }
        [Required]
        public string? Contato { get; set; }
        public double MediaEstrelas { get; set; }
        
        // Avaliações relacionadas a este hotel
        public List<Avaliacao>? Avaliacoes { get; set; }
        
    }
}
