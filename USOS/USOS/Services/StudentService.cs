using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetByIndex(int id);
        int Add(StudentAdd student);
        void Del(int index);
        bool Update(int index, StudentUpdate student);
    }

    public class StudentService : IStudentService
    {
        private readonly UsosDbContext _dbContext;

        public StudentService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Student> GetAll()
        {
            var results = _dbContext.Students.ToList();
            return results;
        }
        public Student GetByIndex(int index)
        {
            var result = _dbContext.Students.SingleOrDefault(x => x.Index == index);
            return result;
        }
        public int Add(StudentAdd student)
        {
            var studentToBeAdded = new Student()
            {
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Index = student.Index,
                MajorSubject = student.MajorSubject,
            };
            _dbContext.Students.Add(studentToBeAdded);
            _dbContext.SaveChanges();
            return studentToBeAdded.Id;
        }
        public void Del(int index)
        {
            var student = _dbContext.Students.SingleOrDefault(y => y.Index == index);
            if (student is null) return;
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
        public bool Update(int index, StudentUpdate student)
        {
            var studentToUpdate = _dbContext.Students.SingleOrDefault(y => y.Index == index);
            if (studentToUpdate is null) return false;
            studentToUpdate.Name = student.Name;
            studentToUpdate.Surname = student.Surname;
            studentToUpdate.MajorSubject = student.MajorSubject;
            _dbContext.Students.Update(studentToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
