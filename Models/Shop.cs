using System.ComponentModel.DataAnnotations;
namespace UserLogin.Models

    
{
    public class Shop
    {
    [Key]
        public int id { get; set; }
    [Required]
        public string Shop_Name { get; set; }
        [Required]
        public string Owner_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
