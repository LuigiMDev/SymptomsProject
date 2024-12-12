using SymptomsProject.Data;
using SymptomsProject.Enums;
using SymptomsProject.Models;

namespace SymptomsProject.Services
{
    public class SeedingService
    {
        private readonly SymptomsContext _context;
        public SeedingService(SymptomsContext context) { _context = context; }

        public async Task Seed()
        {
            if (_context.Symptoms.Any() | _context.Patients.Any()) 
            {
                return;
            }
            List<Patient> patients = new List<Patient>
            {
                new Patient { Name = "John Doe", PhoneNumber = "+55 (11) 98765-4321", Email = "johndoe@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Jane Smith", PhoneNumber = "+55 (21) 98765-4321", Email = "janesmith@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Alice Johnson", PhoneNumber = "+55 (31) 98765-4321", Email = "alicejohnson@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Bob Brown", PhoneNumber = "+55 (41) 98765-4321", Email = "bobbrown@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Charlie White", PhoneNumber = "+55 (51) 98765-4321", Email = "charliewhite@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "David Green", PhoneNumber = "+55 (61) 98765-4321", Email = "davidgreen@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Eve Adams", PhoneNumber = "+55 (71) 98765-4321", Email = "eveadams@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Frank Miller", PhoneNumber = "+55 (81) 98765-4321", Email = "frankmiller@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Grace Wilson", PhoneNumber = "+55 (91) 98765-4321", Email = "gracewilson@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Patient { Name = "Hannah Lewis", PhoneNumber = "+55 (101) 98765-4321", Email = "hannahlewis@example.com", CreationDate = DateTime.Now, EditDate = DateTime.Now }
            };

            _context.Patients.AddRange(patients);
            await _context.SaveChangesAsync();

            List<Symptom> symptoms = new List<Symptom>
            {
                new Symptom { Description = "Dor de cabeça intensa", SeverityType = SeverityType.Moderate, SymptomTypes = new List<SymptomType> { SymptomType.Fever, SymptomType.Cough }, Patient = patients[0], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Tosse seca", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.Cough }, Patient = patients[1], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Dor muscular", SeverityType = SeverityType.Moderate, SymptomTypes = new List<SymptomType> { SymptomType.MusclePain }, Patient = patients[2], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Dificuldade respiratória", SeverityType = SeverityType.Severe, SymptomTypes = new List<SymptomType> { SymptomType.ShortnessOfBreath }, Patient = patients[3], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Febre alta", SeverityType = SeverityType.Moderate, SymptomTypes = new List<SymptomType> { SymptomType.Fever }, Patient = patients[4], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Calafrios", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.Fatigue }, Patient = patients[5], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Dor de garganta", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.SoreThroat }, Patient = patients[6], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Dor abdominal", SeverityType = SeverityType.Moderate, SymptomTypes = new List<SymptomType> { SymptomType.Diarrhea }, Patient = patients[7], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Vômito", SeverityType = SeverityType.Severe, SymptomTypes = new List<SymptomType> { SymptomType.Vomiting }, Patient = patients[8], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Diarréia", SeverityType = SeverityType.Moderate, SymptomTypes = new List<SymptomType> { SymptomType.Diarrhea }, Patient = patients[9], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Nariz escorrendo", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.RunnyNose }, Patient = patients[0], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Irritação nos olhos", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.EyeIrritation }, Patient = patients[1], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Irritação na pele", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.SkinRash }, Patient = patients[2], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Náusea persistente", SeverityType = SeverityType.Moderate, SymptomTypes = new List<SymptomType> { SymptomType.Nausea }, Patient = patients[3], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Falta de ar leve", SeverityType = SeverityType.Mild, SymptomTypes = new List<SymptomType> { SymptomType.ShortnessOfBreath }, Patient = patients[4], CreationDate = DateTime.Now, EditDate = DateTime.Now },
                new Symptom { Description = "Febre persistente", SeverityType = SeverityType.Severe, SymptomTypes = new List<SymptomType> { SymptomType.Fever }, Patient = patients[5], CreationDate = DateTime.Now, EditDate = DateTime.Now }
            };

            _context.Symptoms.AddRange(symptoms);
            await _context.SaveChangesAsync();
        } 
    }
}
