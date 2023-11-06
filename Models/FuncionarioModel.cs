using System;
using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }

    }
}