using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Cpf { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contato { get; set; }

        // Lista de reservas e avaliações relacionadas a este cliente
        public List<Reserva>? Reservas { get; set; }
        public List<Avaliacao>? Avaliacoes { get; set; }

    }
}
