using SymptomsProject.Enums;
using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Validations
{
    public class ListValidation :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IList<object> list && list.Any())
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? "Selecione ao menos um item.");
        }
    }
}
