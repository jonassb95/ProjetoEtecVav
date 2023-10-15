namespace Loto.Prize.Presentation.Models
{
    public class JogoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int TotalNumero { get; set; }
        public int QuantidadeNumeroSelecao { get; set; }
        public string NumerosSorteados { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataSorteio { get; set; }
        public string Premio { get; set; }
    }
}
