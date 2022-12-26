using System.ComponentModel.DataAnnotations;
namespace UserLogin.Models
{
    public class Payment
    {
        [Key]
        public int id { get; set; }
        public string Card_Name { get; set; }
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long Mobile { get; set; }
       
        //[RegularExpression(@"^([0-9]{16})$", ErrorMessage = "Invalid Card Number.")]
        public long Card_Number { get; set; }
        [Required]
        public int Ex_Month { get; set; }
        [Required]
        public int Ex_Year { get; set; }
        [Required]
        public int CVV { get; set; }
        [Required]
        public int Amount { get; set; }

    }
}
