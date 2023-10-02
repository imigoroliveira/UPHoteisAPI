using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Endereco { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public int Estrelas { get; set; }


    }
}
