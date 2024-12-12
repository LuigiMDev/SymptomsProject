using SymptomsProject.Enums;
using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Models
{
    public class Symptom
    {
        public int Id { get; set; }
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Patient Patient { get; set; }
        [Display(Name = "Severidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public SeverityType SeverityType { get; set; }
        [Display(Name = "Sintomas")]
		[RequiredList]
        public IList<SymptomType> SymptomTypes { get; set;} = new List<SymptomType>();
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Description { get; set; }
        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Data de Alteração")]
        public DateTime EditDate { get; set; }
    }
}
