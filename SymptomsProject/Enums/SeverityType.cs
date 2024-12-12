using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Enums
{
    public enum SeverityType
    {
        [Display(Name = "Leve")]
        Mild,
        [Display(Name = "Moderado")]
        Moderate,
        [Display(Name = "Severo")]
        Severe,
        [Display(Name = "Crítico")]
        Critical
    }
}
