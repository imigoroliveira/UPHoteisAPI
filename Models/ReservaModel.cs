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
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public double ValorTotal { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int QuartoId { get; set; }
        public Quarto? Quarto { get; set; }

        // Lista de serviços relacionadas a esta reserva
        public List<ServicoQuarto>? ServicosQuarto { get; set; }

    }
}
