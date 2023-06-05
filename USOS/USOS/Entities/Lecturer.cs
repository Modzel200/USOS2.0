using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USOS.Entities
{
    public class Lecturer
    {
        [Key]
        public int LecturerID { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required"), MaxLength(25, ErrorMessage = "Max length is 25 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Title is required"), DataType(DataType.Text)]
        public string AcademicTitle { get; set; }
        public virtual IList<LecturerSubject> LecturerSubject { get; set; } 
    }
}
