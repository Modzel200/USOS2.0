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
                if (!_context.Subjects.Any())
                {
                    var subjects = GetSubjects();
                    _context.Subjects.AddRange(subjects);
                    _context.SaveChanges();
                }
                if (!_context.MajorSubjects.Any())
                {
                    var majorSubjects = GetMajorSubjects();
                    _context.MajorSubjects.AddRange(majorSubjects);
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
        private IEnumerable<Subject> GetSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject()
                {
                    Name = "Biologia",
                    ShortDesc = "Witam Cie kolezanko",
                    Semester = 3,
                },
                new Subject()
                {
                    Name = "Matematyka dyskretna",
                    ShortDesc = "Tomek zdasz to? xdd",
                    Semester = 2,
                },
            };
            return subjects;
        }
        private IEnumerable<MajorSubject> GetMajorSubjects()
        {
            var majorSubjects = new List<MajorSubject>()
            {
                new MajorSubject()
                {
                    Name = (Major)1,
                    ShortDesc = "Ciezki kierunek",
                    Subjects = new List<Subject>()
                    {
                        new Subject()
                        {
                            Name = "Matematyka dyskretna",
                            ShortDesc = "Tomek zdasz to? xdd",
                            Semester = 2,
                        },
                    },
                },
                new MajorSubject()
                {
                    Name = (Major)3,
                    ShortDesc = "Latwy kierunek (zarzadzanie)",
                    Subjects = new List<Subject>()
                    {
                        new Subject()
                        {
                            Name = "WF",
                            ShortDesc = "Pobiegaj se kupera",
                            Semester = 3,
                        },
                    },
                },
            };
            return majorSubjects;
        }
    }
}
