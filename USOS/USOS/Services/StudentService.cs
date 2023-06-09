﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using USOS.Entities;
using USOS.Models;

namespace USOS.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentGet> GetAll();
        StudentGet GetByIndex(int id);
        int Add(StudentAdd student);
        void Del(int index);
        bool Update(int index, StudentUpdate student);
        public string GetHisMajorSubject(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly UsosDbContext _dbContext;

        public StudentService(UsosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetHisMajorSubject(int id)
        {
            var student = _dbContext.Students.SingleOrDefault(x => x.StudentID == id);
            if (student is null) return null;
            return student.majorSubject.Name;
        }
        public IEnumerable<StudentGet> GetAll()
        {
            var results = _dbContext.Students
                .Select(x => new StudentGet
                {
                    Index = x.Index,
                    Name = x.Name,
                    Surname = x.Surname,
                    Age = x.Age,
                    majorSubject = new MajorSubjectGet
                    {
                        MajorSubjectID = x.MajorSubjectID,
                        Name = x.majorSubject.Name,
                        ShortDesc = x.majorSubject.ShortDesc,
                        Subjects = null,
                    }
                }).ToList();
            return results;
        }
        public StudentGet GetByIndex(int index)
        {
            var result = _dbContext.Students
                .Select(x => new StudentGet
                {
                    Index = x.Index,
                    Name = x.Name,
                    Surname = x.Surname,
                    Age = x.Age,
                    majorSubject = new MajorSubjectGet
                    {
                        Name = x.majorSubject.Name,
                        ShortDesc = x.majorSubject.ShortDesc,
                        Subjects = null,
                    }
                }).SingleOrDefault();
            return result;
        }
        public int Add(StudentAdd student)
        {
            var studentToBeAdded = new Student()
            {
                Name = student.Name,
                Surname = student.Surname,
                Index = student.Index,
                Age = student.Age,
            };
            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(x => x.Name == student.MajorSubject);
            studentToBeAdded.majorSubject = majorSubject;
            studentToBeAdded.MajorSubjectID = majorSubject.MajorSubjectID;
            if (majorSubject.Students.IsNullOrEmpty()) majorSubject.Students = new List<Student>();
            majorSubject.Students.Add(studentToBeAdded);
            _dbContext.SaveChanges();
            return studentToBeAdded.StudentID;
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
            var majorSubject = _dbContext.MajorSubjects.SingleOrDefault(x => x.Name == student.MajorSubject);
            if (studentToUpdate is null) return false;
            studentToUpdate.Name = student.Name;
            studentToUpdate.Surname = student.Surname;
            studentToUpdate.Age = student.Age;
            studentToUpdate.majorSubject = majorSubject;
            studentToUpdate.MajorSubjectID = majorSubject.MajorSubjectID;
            _dbContext.Students.Update(studentToUpdate);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
