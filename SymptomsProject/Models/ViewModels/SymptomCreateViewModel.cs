using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Models.ViewModels
{
    public class SymptomCreateViewModel
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Paciente")]
        public int PatientSelectedId { get; set; }
        public Symptom Symptom { get; set; }
    }
}
