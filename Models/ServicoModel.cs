using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
     // CreatedByChatGPT
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        public bool Reservado { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public int QuartoId { get; set; }
        [ForeignKey("QuartoId")]
        public Quarto Quarto { get; set; }
    }
}
