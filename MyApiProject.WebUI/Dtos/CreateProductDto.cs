using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebUI.Dtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
        public Category Category { get; set; } // Navigation property
    }
}
