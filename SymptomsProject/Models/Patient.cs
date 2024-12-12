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
        [Required(ErrorMessage = "O número de telefone é obrigatório")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+55 \(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O número de telefone deve estar no formato +55 (XX) XXXXX-XXXX")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; }
        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Data de Alteração")]
        public DateTime EditDate { get; set; }
        [Display(Name = "Sintomas do paciente")]
        public ICollection<Symptom> Symptoms { get; set; } = new List<Symptom>();
    }
}
