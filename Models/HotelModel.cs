using System.ComponentModel.DataAnnotations;

namespace UPHoteisAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Endereco { get; set; }

        [Required]
        public string? Descricao { get; set; }

        [Required]
        public List<Avaliacao> Avaliacoes { get; set; }
        
        public double MediaEstrelas
        {
            get
            {
                if (Avaliacoes == null || Avaliacoes.Count == 0)
                {
                    return 0;
                }
                double totalEstrelas = Avaliacoes.Sum(avaliacao => avaliacao.Estrelas);
                return totalEstrelas / Avaliacoes.Count;
            }
        }

    }
}
