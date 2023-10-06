using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPHoteisAPI.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public bool Disponibilidade { get; set; }


        public string HorarioFuncionamento { get; set; }
    }
}
