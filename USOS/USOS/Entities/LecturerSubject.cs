using System.Text.Json.Serialization;

namespace USOS.Entities
{
    public class LecturerSubject
    {
        public int LecturerID { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
