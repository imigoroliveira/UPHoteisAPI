using System;
using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    // CreatedByChatGPT

    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int Estrelas { get; set; }

        public int ClienteId { get; set; }

        public int HotelId { get; set; }

    }
}
