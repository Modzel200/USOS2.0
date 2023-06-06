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
        private void deleteOldRelation(int id)
        {
            var relationToDelete = _dbContext.LecturerSubjects.Where(x => x.LecturerID == id);
            if (relationToDelete.IsNullOrEmpty()) return;
            _dbContext.LecturerSubjects.RemoveRange(relationToDelete);
            _dbContext.SaveChanges();
        }
        private void addNewRelation(int id, ICollection<string> Subjects)
        {
            var lecturer = _dbContext.Lecturers.SingleOrDefault(x => x.LecturerID == id);
            foreach (string elem in Subjects)
            {
                var subject = _dbContext.Subjects.SingleOrDefault(x => x.Name == elem);
                var relation = new LecturerSubject()
                {
                    Lecturer = lecturer,
                    Subject = subject,
                };
                _dbContext.LecturerSubjects.Add(relation);
            }
            _dbContext.SaveChanges();
        }
        public bool ManageSubjects(int id, ICollection<string> Subjects)
        {
            if (_dbContext.Lecturers.SingleOrDefault(x => x.LecturerID == id) is null || Subjects.IsNullOrEmpty()) return false;
            deleteOldRelation(id);
            addNewRelation(id, Subjects);
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
