using Microsoft.EntityFrameworkCore;

namespace USOS.Entities
{
    public class UsosDbContext : DbContext
    {
        private string _ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=USOSDb;Trusted_Connection=True;";
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MajorSubject> MajorSubjects { get; set; }
        public DbSet<SubjectMajorSubject> SubjectMajorSubjects { get; set; }
        public DbSet<LecturerSubject> LecturerSubjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MajorSubject>()
                .HasMany<Student>(x => x.Students)
                .WithOne(x => x.majorSubject)
                .HasForeignKey(x => x.MajorSubjectID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LecturerSubject>().HasKey(ls => new { ls.LecturerID, ls.SubjectID });
            modelBuilder.Entity<LecturerSubject>()
                .HasOne<Lecturer>(ls => ls.Lecturer)
                .WithMany(x => x.LecturerSubject)
                .HasForeignKey(ls => ls.LecturerID);
            modelBuilder.Entity<SubjectMajorSubject>().HasKey(sm => new { sm.SubjectID, sm.MajorSubjectID });
            modelBuilder.Entity<SubjectMajorSubject>()
                .HasOne<Subject>(sm => sm.Subject)
                .WithMany(x => x.SubjectMajorSubject)
                .HasForeignKey(sm => sm.SubjectID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }

    }
}
