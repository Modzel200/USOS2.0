using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface ILecturerService
    {
        int Add(LecturerAddUpdate lecturer);
        //void Del(int id);
        IEnumerable<LecturerGet> GetAll();
        LecturerGet GetById(int id);
        public void ManageSubjects(int id, ICollection<string> Subjects);
        //bool Update(int id, LecturerUpdate lecturer);
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
        public void ManageSubjects(int id, ICollection<string> Subjects)
        {
            //todo
        }
        public int Add(LecturerAddUpdate lecturer)
        {
            var lecturerToBeAdded = new Lecturer()
            {
                Name = lecturer.Name,
                Surname = lecturer.Surname,
                AcademicTitle = lecturer.AcademicTitle,
            };
            //foreach (string elem in lecturer.Subjects)
            //{
            //    var subject = _dbContext.Subjects.Where(x => x.Name == elem).FirstOrDefault();
            //    var lecturerSubject = new LecturerSubject()
            //    {
            //        Subject = subject,
            //        Lecturer = lecturerToBeAdded,
            //    };
            //    _dbContext.LecturerSubjects.Add(lecturerSubject);
            //} to do przemieszczenia do addsubjecttolecturer
            _dbContext.SaveChanges();
            return lecturerToBeAdded.LecturerID;
        }
        //public void Del(int id)
        //{
        //    var lecturer = _dbContext.Lecturers.SingleOrDefault(y => y.Id == id);
        //    if (lecturer is null) return;
        //    _dbContext.Lecturers.Remove(lecturer);
        //    _dbContext.SaveChanges();
        //}
        //public bool Update(int id, LecturerUpdate lecturer)
        //{
        //    List<Subject> subjectsToBeReplaced = new List<Subject>();
        //    foreach (string elem in lecturer.Subjects)
        //    {
        //        subjectsToBeReplaced.Add(_dbContext.Subjects.Where(x => x.Name == elem).FirstOrDefault());
        //    }
        //    var lecturerToUpdate = _dbContext.Lecturers.SingleOrDefault(y => y.Id == id);
        //    if (lecturerToUpdate is null) return false;
        //    lecturerToUpdate.Name = lecturer.Name;
        //    lecturerToUpdate.Surname = lecturer.Surname;
        //    lecturerToUpdate.Subjects = subjectsToBeReplaced;
        //    _dbContext.Lecturers.Update(lecturerToUpdate);
        //    _dbContext.SaveChanges();
        //    return true;
        //}
    }
}
