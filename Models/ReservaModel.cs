using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        [Required]
        public DateTime DataSaida { get; set; }

        [Required]
        public int NumeroQuarto { get; set; }

        public decimal PrecoTotal { get; set; }

        [Required]
        public bool EstaConfirmada { get; set; }
    }
}
