using System.Collections;
using System.ComponentModel.DataAnnotations;

public class RequiredListAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Verifica se o valor é uma lista
        var list = value as IList;
        if (list == null || list.Count == 0)
        {
            return new ValidationResult(ErrorMessage ?? "Você deve selecionar pelo menos uma opção.");
        }

        return ValidationResult.Success;
    }
}