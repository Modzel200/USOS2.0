using Microsoft.EntityFrameworkCore;

namespace USOS.Entities
{
    public class UsosDbContext : DbContext
    {
        private string _ConnectionString = "Server=(localdb)\\Local;Database=USOSDb;Trusted_Connection=True;";
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Student>()
                .Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Student>()
                .Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Student>()
                .Property(x => x.Index)
                .IsRequired()
                .HasMaxLength(6)
                

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }

    }
}
