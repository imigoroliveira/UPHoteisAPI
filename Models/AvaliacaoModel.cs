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
        public string? Descricao { get; set; }
        [Required]
        public int Estrelas { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
