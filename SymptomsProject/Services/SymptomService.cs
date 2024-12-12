using Microsoft.EntityFrameworkCore;
using SymptomsProject.Data;
using SymptomsProject.Models;

namespace SymptomsProject.Services
{
    public class SymptomService
    {
        private readonly SymptomsContext _context;

        public SymptomService(SymptomsContext context)
        {
            _context = context;
        }

        public async Task<List<Symptom>> FindAllAsync()
        {
            return await _context.Symptoms.Include(x => x.Patient).ToListAsync();
        }

        public async Task<Symptom> FindByIdAsync(int id)
        {
            return await _context.Symptoms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Symptom editSymptom)
        {
                _context.Update(editSymptom);
                await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Symptom symptom = await _context.Symptoms.FirstOrDefaultAsync(x => x.Id == id);
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
        }
    }
}
