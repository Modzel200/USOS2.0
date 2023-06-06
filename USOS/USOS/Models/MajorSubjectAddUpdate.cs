using System.ComponentModel.DataAnnotations;
using USOS.Entities;

namespace USOS.Models
{
    public class MajorSubjectAddUpdate
    {
        [Required(ErrorMessage = "Name is required"), MaxLength(40, ErrorMessage = "Max length is 40 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string? ShortDesc { get; set; }
    }
}
