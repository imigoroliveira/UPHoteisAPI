using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public string NomeCliente { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        public double PrecoTotal { get; set; }

        public int QuartoId { get; set; }

        public bool EstaConfirmada { get; set; }
        public required Quarto Quarto { get; set; }
        public int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }

    }
}
