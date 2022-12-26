using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserLogin.Models

{
    public class Registration
    {
        [Key]
        public int UID { get; set; }
       
        public string Fname { get; set; }
        
        public string Lname { get; set; }
       
        public string Mobile { get; set; }
       
        public string Gender { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
  
        public string Pincode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
    }

}
