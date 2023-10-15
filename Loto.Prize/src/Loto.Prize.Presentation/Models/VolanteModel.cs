namespace Loto.Prize.Presentation.Models
{
    public class VolanteModel
    {
        public Guid Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdJogo { get; set; }
        public string NumerosEscolhidos { get; set; }
        public DateTime DataVolante { get; set; }
    }
}
