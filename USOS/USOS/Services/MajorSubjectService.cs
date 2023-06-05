using Microsoft.EntityFrameworkCore;
using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface IMajorSubjectService
    {
        int Add(MajorSubjectAddUpdate majorSubject);
        void Del(int id);
        IEnumerable<MajorSubject> GetAll();
        MajorSubject GetById(int id);
        bool Update(int id, MajorSubjectAddUpdate majorSubject);
    }

    public class MajorSubjectService : IMajorSubjectService
    {
        private readonly UsosDbContext _dbContext;

        public MajorSubjectService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MajorSubject> GetAll()
        {
            var results = _dbContext.MajorSubjects.Include(x => x.Subjects).ToList();
            return results;
        }
        public MajorSubject GetById(int id)
        {
            var result = _dbContext.MajorSubjects.Include(x => x.Subjects).SingleOrDefault(x => x.Id == id);
            return result;
        }
        public int Add(MajorSubjectAddUpdate majorSubject)
        {
            var majorSubjectToBeAdded = new MajorSubject()
            {
                Name = (Enums.Major)majorSubject.Name,
                ShortDesc = majorSubject.ShortDesc,
                Subjects = majorSubject.Subjects,
            };
            _dbContext.MajorSubjects.Add(majorSubjectToBeAdded);
            _dbContext.SaveChanges();
            return majorSubjectToBeAdded.Id;
        }
        public void Del(int id)
        {
            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(y => y.Id == id);
            if (majorSubject is null) return;
            _dbContext.MajorSubjects.Remove(majorSubject);
            _dbContext.SaveChanges();
        }
        public bool Update(int id, MajorSubjectAddUpdate majorSubject)
        {
            var majorSubjectToUpdate = _dbContext.MajorSubjects.SingleOrDefault(y => y.Id == id);
            if (majorSubjectToUpdate is null) return false;
            majorSubjectToUpdate.Name = (Enums.Major)majorSubject.Name;
            majorSubjectToUpdate.ShortDesc = majorSubject.ShortDesc;
            majorSubject.Subjects = majorSubject.Subjects;
            _dbContext.MajorSubjects.Update(majorSubjectToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
