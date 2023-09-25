using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public bool IsConfirmed { get; set; }
    }
}
