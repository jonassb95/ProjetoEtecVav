using System;
using System.ComponentModel.DataAnnotations;
using TesteDeNumeros.Enums;

namespace TesteDeNumeros.Models
{
    public class UsuariosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite seu e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite sua senha")]
        public string Senha { get; set; }

        public PerfilEnum Perfil { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
