using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public decimal Stock { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
        public Category Category { get; set; } // Navigation property
    }
}
