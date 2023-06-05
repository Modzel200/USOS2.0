namespace USOS.Entities
{
    public class SubjectMajorSubject
    {
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
        public int MajorSubjectID { get; set; }
        public virtual MajorSubject MajorSubject { get; set; }
    }
}
