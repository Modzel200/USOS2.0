using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USOS.Entities
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required(ErrorMessage = "Nickame is required"), MaxLength(20, ErrorMessage = "Max length is 20 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Username is required"), MaxLength(25, ErrorMessage = "Max length is 25 characters"), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Only characters are allowed"), DataType(DataType.Text, ErrorMessage = "Only characters are allowed")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required"), DataType(DataType.Text), MaxLength(64, ErrorMessage = "Max length is 64 characters")]
        public string Password { get; set; }
    }
}
