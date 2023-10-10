using System.ComponentModel.DataAnnotations;

namespace LotoPrize.Models
{
    public class LoginModel
    {
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite seu e-mail")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite sua senha")]
        public string Senha { get; set; }
    }
}
