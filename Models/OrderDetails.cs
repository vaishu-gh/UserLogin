using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;

namespace UserLogin.Models
{
    public class OrderDetails
    {
        [Key]
        public int Orderid { get; set; }
        [Required]
        public int UID { get; set; }

        public string ItemName { get; set; }
        public int Quantity { get; set; }

        public int Price { get; set; }
        public string Address { get; set; }
        public string TimeSlot { get; set; }
        

    }
}
