using System.ComponentModel.DataAnnotations;
using USOS.Enums;

namespace USOS.Entities
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required"), MaxLength(25, ErrorMessage = "Max length is 25 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Title is required"), DataType(DataType.Currency)]
        public Title AcademicTitle { get; set; }
        [Required(ErrorMessage = "Major subject is required")]
        public Major MajorSubject { get; set; }
    }
}
