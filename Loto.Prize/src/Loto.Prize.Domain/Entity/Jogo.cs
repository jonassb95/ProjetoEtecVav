using Loto.Prize.Domain.Entity.Base;

namespace Loto.Prize.Domain.Entity
{
    public class Jogo : BaseEntity
    {
        public string Nome { get; set; }
        public int TotalNumero { get; set; }
        public int QuantidadeNumeroSelecao { get; set; }
        public string NumerosSorteados { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataSorteio { get; set; }
        public string Premio { get; set; }

        public Jogo(string nome, int totalNumero, int quantidadeNumeroSelecao, string premio, DateTime dataSorteio)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TotalNumero = totalNumero;
            QuantidadeNumeroSelecao = quantidadeNumeroSelecao;
            DataCriacao = DateTime.Now;
            DataSorteio = dataSorteio;
            Premio = premio;

            ValidarJogo();
        }

        private void ValidarJogo()
        {
            if (!(Nome.Length >= 3 && Nome.Length <= 50))
            {
                AdicionarErro(1, "O nome precisa estar entre 3 a 50 caracteres");
            }

            if (!(TotalNumero >= 10 && TotalNumero <= 1000))
            {
                AdicionarErro(2, "O total de números precisa estar entre 10 a 1000 números");
            }

            if (!(DataSorteio <= DataCriacao.AddHours(6)))
            {
                AdicionarErro(3, "Só é possivel denifir a hora do sorteio para 6 horas após a data de criação");
            }

            if (String.IsNullOrEmpty(Premio))
            {
                AdicionarErro(4, "É necessário a definição do premio");
            }
        }

        private void AdicionarErro(int code, string mensagem)
        {
            var validacao = new RetornoEntity();

            validacao.Code = code;
            validacao.Mensagem = mensagem;

            ListaRetorno.Add(validacao);
        }
    }
}
