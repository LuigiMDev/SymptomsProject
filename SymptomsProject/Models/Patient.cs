using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; }
        [Display(Name = "Número de telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }
        [Display(Name = "Data de Criação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Data de Alteração")]
        public DateTime EditDate { get; set; }
        [Display(Name = "Sintomas do paciente")]
        public ICollection<Symptom> Symptoms { get; set; } = new List<Symptom>();
    }
}
