using System.ComponentModel.DataAnnotations;

namespace PeneiraAraxa.Models
{
    public class Resultado
    {
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe se o jogador foi aprovado")]
        public bool? Aprovado { get; set; }
    }
}
