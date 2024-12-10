using SymptomsProject.Enums;
using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Models
{
    public class Symptom
    {
        public int Id { get; set; }
        [Display(Name = "Paciente")]
        public Patient Patient { get; set; }
        [Display(Name = "Severidade")]
        public SeverityType SeverityType { get; set; }
        [Display(Name = "Sintomas")]
        public IList<SymptomType> SymptomTypes { get; set;} = new List<SymptomType>();
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
    }
}
