using USOS.Enums;

namespace USOS.Entities
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Title AcademicTitle { get; set; }
        public Major MajorSubject { get; set; }
    }
}
