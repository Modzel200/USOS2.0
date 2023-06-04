using System.ComponentModel.DataAnnotations;
using USOS.Enums;

namespace USOS.Entities
{
    public class MajorSubject
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string? ShortDesc { get; set; }
        [Required(ErrorMessage = "Subjects are required")]
        public virtual List<Subject> Subjects { get; set; }
    }
}
