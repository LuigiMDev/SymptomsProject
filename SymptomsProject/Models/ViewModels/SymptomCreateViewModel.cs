namespace SymptomsProject.Models.ViewModels
{
    public class SymptomCreateViewModel
    {
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public int PatientSelectedId { get; set; }
        public Symptom Symptom { get; set; }
    }
}
