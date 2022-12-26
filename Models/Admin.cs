using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserLogin.Models

{
    public class Admin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Key]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
