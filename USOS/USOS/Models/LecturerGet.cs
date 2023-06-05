using System.ComponentModel.DataAnnotations;
using USOS.Entities;
using USOS.Enums;

namespace USOS.Models
{
    public class LecturerGet
    {
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Title AcademicTitle { get; set; }
        public IList<SubjectGet> Subjects { get; set; }
    }
}
