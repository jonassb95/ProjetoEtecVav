using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace TesteDeNumeros.Models
{
    public class JogosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MaximoNumeros { get; set; }
        public int QtdNumeros {get; set;}
        public string NumerosSorteado { get; set;}
        public DateTime DataCriacao { get; set; }  = DateTime.Now;
        public DateTime DataSorteio {  get; set; }

    }
}
