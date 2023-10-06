using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Quarto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Numero { get; set;}
        
        [Required]
        public string Descricao { get; set; }

        [Required]
        public double ValorDiaria { get; set; }
        public bool Disponibilidade { get; set; }
        public int HotelId { get; set; }
        
    }
}