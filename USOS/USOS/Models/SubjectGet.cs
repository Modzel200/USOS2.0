using USOS.Entities;

namespace USOS.Models
{
    public class SubjectGet
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public string? ShortDesc { get; set; }
        public int Semester { get; set; }
    }
}
