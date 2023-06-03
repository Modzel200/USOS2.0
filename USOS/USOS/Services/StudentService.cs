using USOS.Entities;

namespace USOS.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
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
    }
}
