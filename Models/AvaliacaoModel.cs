using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int Estrelas { get; set; }
        [Required]
        public string? Descricao { get; set; }

    }
}
