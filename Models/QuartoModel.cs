using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Quarto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Disponibilidade { get; set; }

        [Required]
        public int QuantidadePessoas { get; set; }

        [Required]
        public int Numero { get; set;}

        [Required]
        public double PrecoDiaria { get; set; }

        public List<Reserva> Reservas { get; set; }
        
    }
}
