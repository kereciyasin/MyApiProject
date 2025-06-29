using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebUI.Dtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
        public Category Category { get; set; } // Navigation property
    }
}
