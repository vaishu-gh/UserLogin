using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserLogin.Models
{
    public class RegContext : DbContext
    {
        internal object id;

        public RegContext(DbContextOptions<RegContext> options) : base(options)
        {

        }
        
     
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Vegetables> Vegetables { get; set; }
        public DbSet<Fruits> Fruits { get; set; }
        public DbSet<Bakery_and_Biscuits> Bakery_and_Biscuits { get; set; }
        public DbSet<Colddrinks> Colddrinks { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<COD> COD { get; set; }
        public DbSet<Admin> Admin { get; set; }
       
        public DbSet<Shop> Shop { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


    }
}
