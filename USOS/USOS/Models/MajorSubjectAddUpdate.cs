using System.ComponentModel.DataAnnotations;
using USOS.Entities;
using USOS.Enums;

namespace USOS.Models
{
    public class MajorSubjectAddUpdate
    {
        [Required(ErrorMessage = "Name is required"), DataType(DataType.Currency, ErrorMessage = "Only numbers are allowed")]
        public int Name { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string? ShortDesc { get; set; }
        [Required(ErrorMessage = "Subjects are required")]
        public virtual List<Subject> Subjects { get; set; }
    }
}
