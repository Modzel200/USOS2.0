using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace USOS.Entities
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string? ShortDesc { get; set; }
        [Required(ErrorMessage = "Semester number is required"), DataType(DataType.Currency, ErrorMessage ="Only numbers are allowed"), Range(1,7,ErrorMessage ="Allowed semesters: 1-7")]
        public int Semester { get; set; }
        public virtual IList<LecturerSubject> LecturerSubject { get; set; }
        public virtual IList<SubjectMajorSubject> SubjectMajorSubject { get; set; }
    }
}
