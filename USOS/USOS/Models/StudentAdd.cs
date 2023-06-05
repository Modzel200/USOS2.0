using System.ComponentModel.DataAnnotations;

namespace USOS.Models
{
    public class StudentAdd
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required"), MaxLength(25, ErrorMessage = "Max length is 25 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Index is required"), DataType(DataType.Currency, ErrorMessage = "Example: 111234")]
        public int Index { get; set; }
        [Required(ErrorMessage = "Age is required"), Range(18, 90, ErrorMessage = "Age must be between 18 and 90"), DataType(DataType.Currency, ErrorMessage = "Only numbers are allowed")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Major Subject is required"), DataType(DataType.Currency, ErrorMessage = "Only numbers are allowed"), Range(0,3,ErrorMessage ="Major Subject must be between 0 and 3")]
        public string MajorSubject { get; set; }
    }
}