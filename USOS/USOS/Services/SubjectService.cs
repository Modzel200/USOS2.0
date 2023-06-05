using Microsoft.EntityFrameworkCore;
using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface ISubjectService
    {
        int Add(SubjectAddUpdate subject);
        void Del(int id);
        IEnumerable<SubjectGet> GetAll();
        SubjectGet GetById(int id);
        //bool Update(int id, SubjectAddUpdate subject);
    }

    public class SubjectService : ISubjectService
    {
        private readonly UsosDbContext _dbContext;

        public SubjectService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<SubjectGet> GetAll()
        {
            var results = _dbContext.Subjects.Select(x => new SubjectGet
            {
                SubjectID = x.SubjectID,
                Name = x.Name,
                ShortDesc = x.ShortDesc,
                Semester = x.Semester,
            }).ToList();
            return results;
        }
        public SubjectGet GetById(int id)
        {
            var result = _dbContext.Subjects.Select(x => new SubjectGet
            {
                SubjectID = x.SubjectID,
                Name = x.Name,
                ShortDesc = x.ShortDesc,
                Semester = x.Semester,
            }).SingleOrDefault(y => y.SubjectID == id);
            return result;
        }
        public int Add(SubjectAddUpdate subject)
        {

            var subjectToBeAdded = new Subject()
            {
                Name = subject.Name,
                ShortDesc = subject.ShortDesc,
                Semester = subject.Semester,
            };
            _dbContext.Subjects.Add(subjectToBeAdded);
            _dbContext.SaveChanges();
            return subjectToBeAdded.SubjectID;
        }
        public void Del(int id)
        {
            
            var subject = _dbContext.Subjects.SingleOrDefault(y => y.SubjectID == id);
            if (subject is null) return;
            var relations = _dbContext.LecturerSubjects.Where(x => x.SubjectID == id).ToList();
            foreach (LecturerSubject elem in relations)
            {
                _dbContext.LecturerSubjects.Remove(elem);
            }
            _dbContext.Subjects.Remove(subject);
            _dbContext.SaveChanges();
        }
        //public bool Update(int id, SubjectAddUpdate subject)
        //{
        //    List<Lecturer> lecturersToBeReplaced = new List<Lecturer>();
        //    List<MajorSubject> majorSubjectsToBeReplaced = new List<MajorSubject>();
        //    foreach (int elem in subject.Lecturers)
        //    {
        //        lecturersToBeReplaced.Add(_dbContext.Lecturers.Where(x => x.Id == elem).FirstOrDefault());
        //    }
        //    foreach (string elem in subject.MajorSubjects)
        //    {
        //        majorSubjectsToBeReplaced.Add(_dbContext.MajorSubjects.Where(x => x.Name == elem).FirstOrDefault());
        //    }
        //    var subjectToUpdate = _dbContext.Subjects.SingleOrDefault(y => y.Id == id);
        //    if (subjectToUpdate is null) return false;
        //    subjectToUpdate.Name = subject.Name;
        //    subjectToUpdate.ShortDesc = subject.ShortDesc;
        //    subjectToUpdate.Semester = subject.Semester;
        //    subjectToUpdate.Lecturers = lecturersToBeReplaced;
        //    subjectToUpdate.MajorSubjects = majorSubjectsToBeReplaced;
        //    _dbContext.Subjects.Update(subjectToUpdate);
        //    _dbContext.SaveChanges();
        //    return true;
        //}
    }
}
