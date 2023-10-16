namespace Loto.Prize.Presentation.Models
{
    public class VolanteModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdJogo { get; set; }
        public string NumerosEscolhidos { get; set; }
        public DateTime DataVolante { get; set; }
    }
}
