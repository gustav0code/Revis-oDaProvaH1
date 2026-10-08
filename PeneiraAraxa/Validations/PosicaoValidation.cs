using System.ComponentModel.DataAnnotations;

namespace PeneiraAraxa.Validations
{
    public class PosicaoValidation : ValidationAttribute
    {
        private readonly string[] _posicoes = { "GL", "ZA", "LD", "LE", "VO", "MD", "AT" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var posicao = value as string;

            if (string.IsNullOrWhiteSpace(posicao))
            {
                return new ValidationResult("A posição é obrigatória.");
            }

            if (!_posicoes.Contains(posicao.ToUpper()))
            {
                return new ValidationResult("Posição inválida. Use GL, ZA, LD, LE, VO, MD ou AT.");
            }

            return ValidationResult.Success;
        }
    }
}
