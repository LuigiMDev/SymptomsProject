using System.ComponentModel.DataAnnotations;

namespace SymptomsProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Número de telefone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Data de Criação")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Data de Alteração")]
        public DateTime EditDate { get; set; }
        //public ICollection<Symptom> Symptoms { get; set; } = new List<Symptom>();
    }
}
