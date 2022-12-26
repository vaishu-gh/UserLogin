using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLogin.Models
{
    public class Vegetables
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public int price { get; set; }
        public int quantity { get; set; }
        
    }
}
