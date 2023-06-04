using System.ComponentModel.DataAnnotations;
using USOS.Enums;

namespace USOS.Models
{
    public class LecturerAdd
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required"), MaxLength(25, ErrorMessage = "Max length is 25 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Title is required"), DataType(DataType.Currency)]
        public int AcademicTitle { get; set; }
        [Required(ErrorMessage = "Major Subject is required"), DataType(DataType.Currency, ErrorMessage = "Only numbers are allowed"), Range(0, 3, ErrorMessage = "Major Subject must be between 0 and 3")]
        public int MajorSubject { get; set; }
    }
}
