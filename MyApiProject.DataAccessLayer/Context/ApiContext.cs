using Microsoft.EntityFrameworkCore;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.DataAccessLayer.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KERECI\\SQLEXPRESS;Database=MyApiProjectDb;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}