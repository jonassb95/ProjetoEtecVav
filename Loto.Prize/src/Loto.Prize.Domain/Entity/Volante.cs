using Loto.Prize.Domain.Entity.Base;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loto.Prize.Domain.Entity
{
    public class Volante : BaseEntity
    {
        public Guid IdJogo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NumerosSelecionados { get; set; }

        // TODO: USUÁRIO

        public Volante(Guid idJogo, string numerosSelecionados)
        {
            Id = Guid.NewGuid();
            IdJogo = idJogo;
            DataCriacao = DateTime.Now;
            NumerosSelecionados = numerosSelecionados;

            ValidarVolante();
        }

        private void ValidarVolante()
        {
            if (String.IsNullOrEmpty(NumerosSelecionados))
            {
                AdicionarErro(1, "É necessário a seleção dos números");
            }

            if (IdJogo == Guid.Empty)
            {
                AdicionarErro(2, "Não é possível criar um volante sem o jogo");
            }

            if (false /* validar data de criação*/)
            {
                // TODO: Puxar no banco de dados o jogo para saber se é possível criar o volante dentro da data estipulada.
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
