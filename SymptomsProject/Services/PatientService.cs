using Microsoft.EntityFrameworkCore;
using SymptomsProject.Data;
using SymptomsProject.Models;

namespace SymptomsProject.Services
{
    public class PatientService
    {
        private readonly SymptomsContext _context;

        public PatientService(SymptomsContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> FindAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Patient> FindByIdAsyncDetails(int id)
        {
            return await _context.Patients.Include(x => x.Symptoms).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Patient editPatient)
        {
                _context.Update(editPatient);
                await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Patient patient = await _context.Patients.FirstOrDefaultAsync(x =>x.Id == id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
