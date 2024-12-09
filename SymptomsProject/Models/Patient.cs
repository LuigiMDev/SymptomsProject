namespace SymptomsProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        //public ICollection<Symptom> Symptoms { get; set; } = new List<Symptom>();
    }
}
