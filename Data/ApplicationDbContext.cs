using Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }


        public DbSet<Patient> Patients { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Email);
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Name);
        }
    }
}
