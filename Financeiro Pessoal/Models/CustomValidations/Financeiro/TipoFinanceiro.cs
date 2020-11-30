using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Financeiro_Pessoal.Models.CustomValidations.Financeiro
{
    public class TipoFinanceiro : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var financeiro = (Models.Financeiro)validationContext.ObjectInstance;

            if (!financeiro.Receita && !financeiro.Despesa)
                return new ValidationResult(ErrorMessage = "O lançamento deve ser destacado como Receita ou Despesa!");
            else if (financeiro.Receita && financeiro.Despesa)
                return new ValidationResult(ErrorMessage = "O lançamento não pode ser Receita e Despesa ao mesmo tempo!");
            else 
                return ValidationResult.Success;
        }
    }
}