using Microsoft.EntityFrameworkCore;

namespace USOS.Entities
{
    public class UsosDbContext : DbContext
    {
        private string _ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=USOSDb;Trusted_Connection=True;";
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }

    }
}
