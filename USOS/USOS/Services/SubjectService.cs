using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface ISubjectService
    {
        int Add(SubjectAddUpdate subject);
        void Del(int id);
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        bool Update(int id, SubjectAddUpdate subject);
    }

    public class SubjectService : ISubjectService
    {
        private readonly UsosDbContext _dbContext;

        public SubjectService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Subject> GetAll()
        {
            var results = _dbContext.Subjects.ToList();
            return results;
        }
        public Subject GetById(int id)
        {
            var result = _dbContext.Subjects.SingleOrDefault(x => x.Id == id);
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
            return subjectToBeAdded.Id;
        }
        public void Del(int id)
        {
            var subject = _dbContext.Subjects.SingleOrDefault(y => y.Id == id);
            if (subject is null) return;
            _dbContext.Subjects.Remove(subject);
            _dbContext.SaveChanges();
        }
        public bool Update(int id, SubjectAddUpdate subject)
        {
            var subjectToUpdate = _dbContext.Subjects.SingleOrDefault(y => y.Id == id);
            if (subjectToUpdate is null) return false;
            subjectToUpdate.Name = subject.Name;
            subjectToUpdate.ShortDesc = subject.ShortDesc;
            subjectToUpdate.Semester = subject.Semester;
            _dbContext.Subjects.Update(subjectToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
