using Microsoft.EntityFrameworkCore;

namespace a
{
    public class PatientDB:DbContext
    {
        public DbSet<Patient> patients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source=patients.db");// Data Source=path to the database file
        }
    }
}
