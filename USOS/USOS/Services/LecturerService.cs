using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface ILecturerService
    {
        int Add(LecturerAdd lecturer);
        void Del(int id);
        IEnumerable<Lecturer> GetAll();
        Lecturer GetById(int id);
        bool Update(int id, LecturerUpdate lecturer);
    }

    public class LecturerService : ILecturerService
    {
        private readonly UsosDbContext _dbContext;

        public LecturerService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Lecturer> GetAll()
        {
            var results = _dbContext.Lecturers.ToList();
            return results;
        }
        public Lecturer GetById(int id)
        {
            var result = _dbContext.Lecturers.SingleOrDefault(x => x.Id == id);
            return result;
        }
        public int Add(LecturerAdd lecturer)
        {
            var lecturerToBeAdded = new Lecturer()
            {
                Name = lecturer.Name,
                Surname = lecturer.Surname,
                AcademicTitle = (Enums.Title)lecturer.AcademicTitle,
                MajorSubject = (Enums.Major)lecturer.MajorSubject
            };
            _dbContext.Lecturers.Add(lecturerToBeAdded);
            _dbContext.SaveChanges();
            return lecturerToBeAdded.Id;
        }
        public void Del(int id)
        {
            var lecturer = _dbContext.Lecturers.SingleOrDefault(y => y.Id == id);
            if (lecturer is null) return;
            _dbContext.Lecturers.Remove(lecturer);
            _dbContext.SaveChanges();
        }
        public bool Update(int id, LecturerUpdate lecturer)
        {
            var lecturerToUpdate = _dbContext.Lecturers.SingleOrDefault(y => y.Id == id);
            if (lecturerToUpdate is null) return false;
            lecturerToUpdate.Name = lecturer.Name;
            lecturerToUpdate.Surname = lecturer.Surname;
            lecturerToUpdate.MajorSubject = (Enums.Major)lecturer.MajorSubject;
            _dbContext.Lecturers.Update(lecturerToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
