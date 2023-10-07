using System;
using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Comentario { get; set; }
        [Required]
        public int NotaAvaliacao { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

    }
}
