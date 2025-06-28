using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebUI.Dtos
{
    public class GetByIdProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public decimal Stock { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
        public Category Category { get; set; } // Navigation property
    }
}
