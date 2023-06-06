using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface ILecturerService
    {
        int Add(LecturerAddUpdate lecturer);
        void Del(int id);
        IEnumerable<LecturerGet> GetAll();
        LecturerGet GetById(int id);
        public bool ManageSubjects(int id, ICollection<string> Subjects);
        bool Update(int id, LecturerAddUpdate lecturer);
    }

    public class LecturerService : ILecturerService
    {
        private readonly UsosDbContext _dbContext;

        public LecturerService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<LecturerGet> GetAll()
        {
            var results = _dbContext.Lecturers
                .Select(x => new LecturerGet
                {
                    LecturerID = x.LecturerID,
                    Name = x.Name,
                    Surname = x.Surname,
                    AcademicTitle = x.AcademicTitle,
                    Subjects = x.LecturerSubject.Select(y => y.Subject).Select(z => new SubjectGet
                    {
                        SubjectID = z.SubjectID,
                        Name = z.Name,
                        ShortDesc = z.ShortDesc,
                        Semester = z.Semester,
                    }).ToList(),
                }).ToList();
            if (results.IsNullOrEmpty())
            {
                return null;
            }
            return results;
        }
        public LecturerGet GetById(int id)
        {
            var result = _dbContext.Lecturers
                .Select(x => new LecturerGet
                {
                    LecturerID = x.LecturerID,
                    Name = x.Name,
                    Surname = x.Surname,
                    AcademicTitle = x.AcademicTitle,
                    Subjects = x.LecturerSubject.Select(y => y.Subject).Select(z => new SubjectGet
                    {
                        SubjectID = z.SubjectID,
                        Name = z.Name,
                        ShortDesc = z.ShortDesc,
                        Semester = z.Semester,
                    }).ToList(),
                }).SingleOrDefault(z => z.LecturerID == id);
            if(result is null)
            {
                return null;
            }
            return result;
        }
        public bool ManageSubjects(int id, ICollection<string> Subjects)
        {
            var relation = _dbContext.LecturerSubjects.Where(x => x.LecturerID == id).ToList();
            var lecturer = _dbContext.Lecturers.FirstOrDefault(x => x.LecturerID == id);
            if(lecturer is null)
            {
                return false;
            }
            foreach(LecturerSubject elem in relation)
            {
                if (elem is null) continue;
                _dbContext.LecturerSubjects.Remove(elem);
            }
            foreach(string elem in Subjects)
            {
                var subject = _dbContext.Subjects.Where(x => x.Name == elem).FirstOrDefault();
                if (subject is null) continue;
                var lecturerSubject = new LecturerSubject()
                {
                    Subject = subject,
                    Lecturer = lecturer,
                };
                _dbContext.LecturerSubjects.Add(lecturerSubject);
            }
            _dbContext.SaveChanges();
            return true;
        }
        public int Add(LecturerAddUpdate lecturer)
        {
            var lecturerToBeAdded = new Lecturer()
            {
                Name = lecturer.Name,
                Surname = lecturer.Surname,
                AcademicTitle = lecturer.AcademicTitle,
            };
            _dbContext.Lecturers.Add(lecturerToBeAdded);
            _dbContext.SaveChanges();
            return lecturerToBeAdded.LecturerID;
        }
        public void Del(int id)
        {
            var lecturer = _dbContext.Lecturers.SingleOrDefault(y => y.LecturerID == id);
            var relations = _dbContext.LecturerSubjects.Where(y => y.LecturerID == id).ToList();
            if (lecturer is null) return;
            if (!relations.IsNullOrEmpty())
            {
                foreach(LecturerSubject elem in relations)
                {
                    _dbContext.LecturerSubjects.Remove(elem);
                }
            }
            _dbContext.Lecturers.Remove(lecturer);
            _dbContext.SaveChanges();
        }
        public bool Update(int id, LecturerAddUpdate lecturer)
        {
            var lecturerToUpdate = _dbContext.Lecturers.SingleOrDefault(y => y.LecturerID == id);
            if (lecturerToUpdate is null) return false;
            lecturerToUpdate.Name = lecturer.Name;
            lecturerToUpdate.Surname = lecturer.Surname;
            lecturerToUpdate.AcademicTitle = lecturer.AcademicTitle;
            _dbContext.Lecturers.Update(lecturerToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
