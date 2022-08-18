using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace CoreBusiness
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string  Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }

        public Category(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }

        public Category()
        {

        }
    }
}