using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class Quarto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Numero { get; set; }
        [Required]
        public string? Tamanho { get; set; }
        [Required]
        public double ValorDiaria { get; set; }
        [Required]
        public bool Disponibilidade { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public List<Reserva>? Reservas { get; set; }

    }
}