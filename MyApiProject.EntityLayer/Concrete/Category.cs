using System.Collections.Generic;

namespace MyApiProject.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; } // Navigation property for related products
    }
}