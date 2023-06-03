using USOS.Enums;

namespace USOS.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Index { get; set;}
        public int Age { get; set; }
        public Major MajorSubject { get; set; }

    }
}
