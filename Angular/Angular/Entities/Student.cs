using System.ComponentModel.DataAnnotations;
using USOS.Enums;

namespace USOS.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage ="Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage ="Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required"), MaxLength(25, ErrorMessage = "Max length is 25 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Index is required"), DataType(DataType.Currency , ErrorMessage ="Example: 111234")]
        public int Index { get; set;}
        [Required(ErrorMessage = "Age is required"), Range(18,90, ErrorMessage ="Age must be between 18 and 90"), DataType(DataType.Currency, ErrorMessage = "Only numbers are allowed")]
        public int Age { get; set; }
        public Major MajorSubject { get; set; }

    }
}
