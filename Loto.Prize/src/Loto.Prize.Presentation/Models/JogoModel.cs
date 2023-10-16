using System.ComponentModel.DataAnnotations;

namespace Loto.Prize.Presentation.Models
{
    public class JogoModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public int TotalNumero { get; set; }
        [Required]
        public int QuantidadeNumeroSelecao { get; set; }
        public string? NumerosSorteados { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataSorteio { get; set; }
        [Required]
        public string Premio { get; set; }

        public JogoModel()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }
    }
}
