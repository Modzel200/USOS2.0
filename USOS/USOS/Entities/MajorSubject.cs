using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USOS.Entities
{
    public class MajorSubject
    {
        [Key]
        public int MajorSubjectID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string? ShortDesc { get; set; }
        public virtual IList<SubjectMajorSubject> SubjectMajorSubject { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
