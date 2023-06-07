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
        public ICollection<string> GetItsSubjects(int id);
        bool Update(int id, MajorSubjectAddUpdate majorSubject);
        public bool ManageSubjects(int id, ICollection<string> Subjects);
    }

    public class MajorSubjectService : IMajorSubjectService
    {
        private readonly UsosDbContext _dbContext;

        public MajorSubjectService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<string> GetItsSubjects(int id)
        {
            var result = new List<string>();
            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(x => x.MajorSubjectID == id);
            if (majorSubject is null) return null;
            List<int> subjectIDs = _dbContext.SubjectMajorSubjects.Where(x => x.MajorSubject == majorSubject).Select(y => y.SubjectID).ToList();
            foreach (int elem in subjectIDs)
            {
                result.Add(_dbContext.Subjects.Where(x => x.SubjectID == elem).Select(y => y.Name).SingleOrDefault());
            }
            return result;
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
        private void deleteOldRelation(int id)
        {
            var relationToDelete = _dbContext.SubjectMajorSubjects.Where(x => x.MajorSubjectID == id);
            if (relationToDelete.IsNullOrEmpty()) return;
            _dbContext.SubjectMajorSubjects.RemoveRange(relationToDelete);
            _dbContext.SaveChanges();
        }
        private void addNewRelation(int id, ICollection<string> Subjects)
        {
            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(x => x.MajorSubjectID == id);
            foreach (string elem in Subjects)
            {
                var subject = _dbContext.Subjects.SingleOrDefault(x => x.Name == elem);
                var relation = new SubjectMajorSubject()
                {
                    MajorSubject = majorSubject,
                    Subject = subject,
                };
                _dbContext.SubjectMajorSubjects.Add(relation);
            }
            _dbContext.SaveChanges();
        }
        public bool ManageSubjects(int id, ICollection<string> Subjects)
        {
            if (_dbContext.MajorSubjects.SingleOrDefault(x => x.MajorSubjectID == id) is null || Subjects.IsNullOrEmpty()) return false;
            deleteOldRelation(id);
            addNewRelation(id, Subjects);
            return true;
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
