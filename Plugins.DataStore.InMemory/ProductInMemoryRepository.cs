using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>() { 
                new Product(1, 1, "Iced Tea", 1.99, 100),
                new Product(2, 1, "Canada Dry", 1.99, 200),
                new Product(3, 2, "Whole Wheat Bread", 1.99, 100),
                new Product(4,2,"White Bread",1.99,100),

            };


        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var DeleteToProduct = GetProductById(productId);
            products?.Remove(DeleteToProduct);

        }

        public Product GetProductById(int productId)
        {
            var product = products.FirstOrDefault(x => x.ProductId == productId);
            return product;
        }

        public IEnumerable<Product> GetProducts() {

        return products;

        }
        public void UpdateProduct(Product product)
        {
            var UpdateToProduct = GetProductById(product.ProductId);
            if (UpdateToProduct != null) {
                UpdateToProduct.Name = product.Name;
                UpdateToProduct.CategoryId = product.CategoryId;
                UpdateToProduct.Price = product.Price;

                UpdateToProduct.Quantity = product.Quantity;
            }
        }

        public IEnumerable<Product> ViewProductsByCategoryId(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }
    }
}
