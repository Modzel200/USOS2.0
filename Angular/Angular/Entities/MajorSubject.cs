using USOS.Enums;

namespace USOS.Entities
{
    public class MajorSubject
    {
        public int Id { get; set; }
        public Major Name { get; set; }
        public string ShortDesc { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
