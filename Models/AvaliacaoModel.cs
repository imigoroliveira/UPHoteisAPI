using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        
        public int HotelId { get; set; }

        public int Estrelas { get; set; }

        public string Descricao { get; set; }

    }
}
