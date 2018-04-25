using Microsoft.EntityFrameworkCore;

namespace NGWSite.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Order> Orders {get;set;}
        public DbSet<OrderItem> OrderItems {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductCategory> ProductCategorys {get;set;}
        public DbSet<Sale> Sales {get;set;}
        public DbSet<Stock> Stocks {get;set;}
    }
}