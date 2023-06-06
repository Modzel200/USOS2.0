using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface IMajorSubjectService
    {
        int Add(MajorSubjectAddUpdate majorSubject);
        void Del(int id);
        IEnumerable<MajorSubjectGet> GetAll();
        MajorSubjectGet GetById(int id);
        IEnumerable<string> GetAllMajorSubjects();
        bool Update(int id, MajorSubjectAddUpdate majorSubject);
    }

    public class MajorSubjectService : IMajorSubjectService
    {
        private readonly UsosDbContext _dbContext;

        public MajorSubjectService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<MajorSubjectGet> GetAll()
        {
            var results = _dbContext.MajorSubjects
                .Select(x => new MajorSubjectGet
                {
                    MajorSubjectID = x.MajorSubjectID,
                    Name = x.Name,
                    ShortDesc = x.ShortDesc,
                    Subjects = x.SubjectMajorSubject.Select(y => y.Subject).Select(z => new SubjectGet
                    {
                        SubjectID = z.SubjectID,
                        Name = z.Name,
                        ShortDesc = z.ShortDesc,
                        Semester = z.Semester,
                    }).ToList(),
                }).ToList();
            return results;
        }
        public MajorSubjectGet GetById(int id)
        {
            var result = _dbContext.MajorSubjects
                .Select(x => new MajorSubjectGet
                {
                    MajorSubjectID = x.MajorSubjectID,
                    Name = x.Name,
                    ShortDesc = x.ShortDesc,
                    Subjects = x.SubjectMajorSubject.Select(y => y.Subject).Select(z => new SubjectGet
                    {
                        SubjectID = z.SubjectID,
                        Name = z.Name,
                        ShortDesc = z.ShortDesc,
                        Semester = z.Semester,
                    }).ToList(),
                }).SingleOrDefault(x => x.MajorSubjectID == id);
            return result;
        }
        public IEnumerable<string> GetAllMajorSubjects()
        {
            List<string> majorSubjects = _dbContext.MajorSubjects.Select(x => x.Name).ToList();
            if (majorSubjects.IsNullOrEmpty()) return null;
            return majorSubjects;
        }
        public int Add(MajorSubjectAddUpdate majorSubject)
        {
            var majorSubjectToBeAdded = new MajorSubject()
            {
                Name = majorSubject.Name,
                ShortDesc = majorSubject.ShortDesc,
            };
            _dbContext.MajorSubjects.Add(majorSubjectToBeAdded);
            _dbContext.SaveChanges();
            return majorSubjectToBeAdded.MajorSubjectID;
        }
        public void Del(int id)
        {
            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(y => y.MajorSubjectID == id);
            if (majorSubject is null) return;
            _dbContext.MajorSubjects.Remove(majorSubject);
            _dbContext.SaveChanges();
        }
        public bool Update(int id, MajorSubjectAddUpdate majorSubject)
        {
            var majorSubjectToUpdate = _dbContext.MajorSubjects.SingleOrDefault(y => y.MajorSubjectID == id);
            if (majorSubjectToUpdate is null) return false;
            majorSubjectToUpdate.Name = majorSubject.Name;
            majorSubjectToUpdate.ShortDesc = majorSubject.ShortDesc;
            _dbContext.MajorSubjects.Update(majorSubjectToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
