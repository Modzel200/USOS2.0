//using Microsoft.EntityFrameworkCore;
//using USOS.Entities;
//using USOS.Models;

//namespace USOS.Services
//{
//    public interface IMajorSubjectService
//    {
//        int Add(MajorSubjectAddUpdate majorSubject);
//        void Del(int id);
//        IEnumerable<MajorSubjectGet> GetAll();
//        MajorSubject GetById(int id);
//        bool Update(int id, MajorSubjectAddUpdate majorSubject);
//    }

//    public class MajorSubjectService : IMajorSubjectService
//    {
//        private readonly UsosDbContext _dbContext;

//        public MajorSubjectService(UsosDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public IEnumerable<MajorSubjectGet> GetAll()
//        {
//            var results = _dbContext.MajorSubjects
//                .Select(x => new MajorSubjectGet
//                {
//                    MajorSubjectID = x.MajorSubjectID,
//                    Name = x.Name,
//                    ShortDesc = x.ShortDesc,
//                    Subjects = x.SubjectMajorSubject.Select(y => y.Subject).Select(z => new SubjectGet
//                    {
//                        SubjectID = z.SubjectID,
//                        Name = z.Name,
//                        ShortDesc = z.ShortDesc,
//                        Semester = z.Semester,
//                    }).ToList(),
//                    Students = x.Students
//                }).ToList();
//            return results;
//        }
//        public MajorSubject GetById(int id)
//        {
//            var result = _dbContext.MajorSubjects.Include(x => x.Subjects).Include(y => y.Students).SingleOrDefault(x => x.Id == id);
//            return result;
//        }
//        public int Add(MajorSubjectAddUpdate majorSubject)
//        {
//            List<Subject> subjectsToBeAdded = new List<Subject>();
//            List<Student> studentsToBeAdded = new List<Student>();
//            foreach (string elem in majorSubject.Subjects)
//            {
//                subjectsToBeAdded.Add(_dbContext.Subjects.Where(x => x.Name == elem).FirstOrDefault());
//            }
//            foreach (int elem in majorSubject.Students)
//            {
//                studentsToBeAdded.Add(_dbContext.Students.Where(x => x.Id == elem).FirstOrDefault());
//            }
//            var majorSubjectToBeAdded = new MajorSubject()
//            {
//                Name = majorSubject.Name,
//                ShortDesc = majorSubject.ShortDesc,
//                Subjects = subjectsToBeAdded,
//                Students = studentsToBeAdded,
//            };
//            _dbContext.MajorSubjects.Add(majorSubjectToBeAdded);
//            _dbContext.SaveChanges();
//            return majorSubjectToBeAdded.Id;
//        }
//        public void Del(int id)
//        {
//            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(y => y.Id == id);
//            if (majorSubject is null) return;
//            _dbContext.MajorSubjects.Remove(majorSubject);
//            _dbContext.SaveChanges();
//        }
//        public bool Update(int id, MajorSubjectAddUpdate majorSubject)
//        {
//            List<Subject> subjectsToBeReplaced = new List<Subject>();
//            List<Student> studentsToBeReplaced = new List<Student>();
//            foreach (string elem in majorSubject.Subjects)
//            {
//                subjectsToBeReplaced.Add(_dbContext.Subjects.Where(x => x.Name == elem).FirstOrDefault());
//            }
//            foreach (int elem in majorSubject.Students)
//            {
//                studentsToBeReplaced.Add(_dbContext.Students.Where(x => x.Id == elem).FirstOrDefault());
//            }
//            var majorSubjectToUpdate = _dbContext.MajorSubjects.SingleOrDefault(y => y.Id == id);
//            if (majorSubjectToUpdate is null) return false;
//            majorSubjectToUpdate.Name = majorSubject.Name;
//            majorSubjectToUpdate.ShortDesc = majorSubject.ShortDesc;
//            majorSubjectToUpdate.Subjects = subjectsToBeReplaced;
//            majorSubjectToUpdate.Students = studentsToBeReplaced;
//            _dbContext.MajorSubjects.Update(majorSubjectToUpdate);
//            _dbContext.SaveChanges();
//            return true;
//        }
//    }
//}
