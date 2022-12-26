using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class Dairy
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public int price { get; set; }
        public int quantity { get; set; }
        public byte[]? image { get; set; }

    }
}
