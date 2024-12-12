using Microsoft.EntityFrameworkCore;
using SymptomsProject.Models;

namespace SymptomsProject.Data
{
    public class SymptomsContext : DbContext
    {
        public SymptomsContext(DbContextOptions<SymptomsContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Symptom>()
                        .HasOne(s => s.Patient)
                        .WithMany(p => p.Symptoms)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
