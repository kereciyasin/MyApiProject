using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.DtoLayer.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public decimal Stock { get; set; }
        public int CategoryId { get; set; } // Foreign key to Category
    }
}
