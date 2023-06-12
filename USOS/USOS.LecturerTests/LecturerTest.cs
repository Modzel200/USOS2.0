using Microsoft.EntityFrameworkCore;
using Moq;
using USOS.Entities;
using USOS.Models;
using USOS.Services;

namespace USOS.Tests;

public class LecturerTest
{
    private LecturerService service;
    [Fact]
    public void GetLecturerByID_ReturnNotFound()
    {
        var db = new UsosDbContext();
        service = new LecturerService(db);
        var serviceResult = service.GetById(999);
        Assert.Null(serviceResult);
    }
    [Fact]
    public void GetAll_ReturnList()
    {
        var db = new UsosDbContext();
        db.Set<Lecturer>().AddRange(new Lecturer
        {
            Name = "Test",
            Surname = "Test",
            AcademicTitle = "Test",
        });
        db.SaveChanges();
        service = new LecturerService(db);
        var serviceResult = service.GetAll();
        service.Del(db.Lecturers.FirstOrDefault(x => x.Name == "Test").LecturerID);
        db.SaveChanges();
        Assert.Equal(serviceResult.Count(), db.Lecturers.ToList().Count());
        
    }
    [Fact]
    public void GetHisSubjects_ReturnList()
    {
        var db = new UsosDbContext();
        db.Set<Lecturer>().AddRange(new Lecturer
        {
            Name = "Test",
            Surname = "Test",
            AcademicTitle = "Test",
        });
        db.Set<Subject>().Add(new Subject
        {
            Name = "Test",
            ShortDesc = "Test",
            Semester = 2,
        });
        db.SaveChanges();
        var Subject = db.Subjects.FirstOrDefault(s => s.Name == "Test");
        var Lecturer = db.Lecturers.FirstOrDefault(s => s.Name == "Test");
        db.LecturerSubjects.Add(new LecturerSubject
        {
            Subject = Subject,
            Lecturer = Lecturer,
        });
        db.SaveChanges();
        service = new LecturerService(db);
        var serviceResult = service.GetHisSubjects(Lecturer.LecturerID);
        db.LecturerSubjects.Remove(db.LecturerSubjects.FirstOrDefault(x => x.Subject == Subject && x.Lecturer == Lecturer));
        db.Subjects.Remove(db.Subjects.FirstOrDefault(x => x.Name == "Test"));
        db.Lecturers.Remove(db.Lecturers.FirstOrDefault(x => x.Name == "Test"));
        db.SaveChanges();
        Assert.Equal(serviceResult.Count(), 1);
        
    }
    [Fact]
    public void Add_ReturnID()
    {
        var db = new UsosDbContext();
        service = new LecturerService(db);
        var serviceResult = service.Add(new LecturerAddUpdate
        {
            Name = "Test",
            Surname = "Test",
            AcademicTitle = "Test"
        });
        var expectedResult = db.Lecturers.FirstOrDefault(x => x.Name == "Test").LecturerID;
        service.Del(serviceResult);
        Assert.Equal(expectedResult, serviceResult);
    }
    [Fact]
    public void Update_ReturnFalse()
    {
        var db = new UsosDbContext();
        service = new LecturerService(db);
        var serviceResult = service.Update(-999, new LecturerAddUpdate
        {
            Name = "Test",
            Surname = "Test",
            AcademicTitle = "Test",
        });
        Assert.False(serviceResult);
    }
}