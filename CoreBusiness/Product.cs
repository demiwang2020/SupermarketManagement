using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {

        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public Product()
        {

        }
        public Product(int ProductId, int CategoryId, string Name, double Price, int Quantity)
        {
            this.ProductId= ProductId;
            this.CategoryId = CategoryId;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public Product(int CategoryId, string Name, double Price, int Quantity)
        {
            this.CategoryId = CategoryId;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
