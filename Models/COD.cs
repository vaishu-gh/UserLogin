using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace UserLogin.Models
{
    public class COD
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long Mobile { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Landmark { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]


        public int Pincode { get; set; }

    }
}
