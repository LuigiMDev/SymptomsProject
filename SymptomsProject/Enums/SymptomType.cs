using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Enums
{
    public enum SymptomType
    {
        [Display(Name = "Febre")]
        Fever,

        [Display(Name = "Tosse")]
        Cough,

        [Display(Name = "Dor de cabeça")]
        Headache,

        [Display(Name = "Dor de garganta")]
        SoreThroat,

        [Display(Name = "Nariz escorrendo")]
        RunnyNose,

        [Display(Name = "Fadiga")]
        Fatigue,

        [Display(Name = "Falta de ar")]
        ShortnessOfBreath,

        [Display(Name = "Dor muscular")]
        MusclePain,

        [Display(Name = "Náusea")]
        Nausea,

        [Display(Name = "Vômito")]
        Vomiting,

        [Display(Name = "Diarreia")]
        Diarrhea,

        [Display(Name = "Irritação na pele")]
        SkinRash,

        [Display(Name = "Irritação nos olhos")]
        EyeIrritation,

        [Display(Name = "Outro")]
        Other
    }
}
