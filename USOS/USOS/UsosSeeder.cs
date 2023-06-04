using USOS.Entities;
using System.Net;
using System.Security.Cryptography;
using USOS.Enums;

namespace USOS
{
    public class UsosSeeder
    {
        private readonly UsosDbContext _context;
        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Students.Any())
                {
                    var students = GetStudents();
                    _context.Students.AddRange(students);
                    _context.SaveChanges();
                }
                if (!_context.Lecturers.Any())
                {
                    var lecturers = GetLecturers();
                    _context.Lecturers.AddRange(lecturers);
                    _context.SaveChanges();
                }
            }
        }
        public UsosSeeder(UsosDbContext context)
        {
            _context = context;
        }
        private IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Name = "Tomek",
                    Surname = "Jogurciarz",
                    Age = 22,
                    Index = 123456,
                    MajorSubject = Major.IT,
                },
                new Student()
                {
                    Name = "Dawid",
                    Surname = "Garnuch",
                    Age = 21,
                    Index = 543456,
                    MajorSubject = Major.IT,
                },
            };
            return students;
        }
        private IEnumerable<Lecturer> GetLecturers()
        {
            var lecturers = new List<Lecturer>()
            {
                new Lecturer()
                {
                    Name = "Witek",
                    Surname = "Tacikiewicz",
                    AcademicTitle = Title.Doctor,
                    MajorSubject = Major.IT,
                },
                new Lecturer()
                {
                    Name = "Kamil",
                    Surname = "Marah",
                    AcademicTitle = Title.Professor,
                    MajorSubject = Major.Physics,
                },
            };
            return lecturers;
        }
    }
}
