using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Models.ViewModels
{
    public class SymptomCreateViewModel
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<SelectListItem> PatientSelect => GeneratePatientsSelect();

        [Required(ErrorMessage = "Error")]
        public List<int> SymptomsTypesIds = new List<int>();

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Paciente")]
        public int PatientSelectedId { get; set; }
        public Symptom Symptom { get; set; }

        private List<SelectListItem> GeneratePatientsSelect()
        {
            List<SelectListItem> patientSelect = new List<SelectListItem>();
            if(Patients.Any())
            {
                foreach(Patient patient in Patients)
                {
                    patientSelect.Add(new SelectListItem { Text = patient.Name, Value = patient.Id.ToString() });
                }
            }
            return patientSelect;
        }
    }
}
