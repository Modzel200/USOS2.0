using USOS.Entities;

namespace USOS.Models
{
    public class MajorSubjectGet
    {
        public int MajorSubjectID { get; set; }
        public string Name { get; set; }
        public string? ShortDesc { get; set; }
        public IList<SubjectGet> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
