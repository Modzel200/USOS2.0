using USOS.Entities;

namespace USOS.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        int Add(Student student);
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
        public int Add(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student.Id;
        }
    }
}
