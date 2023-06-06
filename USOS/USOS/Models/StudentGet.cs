using USOS.Entities;

namespace USOS.Models
{
    public class StudentGet
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Index { get; set; }
        public int Age { get; set; }
        public virtual MajorSubjectGet majorSubject { get; set; }
    }
}
