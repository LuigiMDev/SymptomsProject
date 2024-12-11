using System.Collections;
using System.ComponentModel.DataAnnotations;

public class RequiredListAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		// Verifica se é uma lista e se contém elementos
		var list = value as IList;
		if (list == null || list.Count == 0)
		{
			return new ValidationResult(ErrorMessage ?? "A lista deve conter pelo menos um item.");
		}

		return ValidationResult.Success;
	}
}
