using System.ComponentModel.DataAnnotations;
using USOS.Entities;

namespace USOS.Models
{
    public class LecturerGet
    {
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AcademicTitle { get; set; }
        public IList<SubjectGet> Subjects { get; set; }
    }
}
