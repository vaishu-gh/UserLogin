using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace UserLogin.Models
{
    public class Menu_Card
    {
        
      
            [Key]
            public int id { get; set; }
            [Required]
            public string? title { get; set; }
            [Required]
            public int price { get; set; }
            public int quantity { get; set; }
            public string? image { get; set; }
            //public byte? Upload_img { get; set; } 
               

       
    }
}
