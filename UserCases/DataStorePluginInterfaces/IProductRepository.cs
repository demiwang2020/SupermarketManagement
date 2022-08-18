using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);

        void UpdateProduct(Product product);

        Product GetProductById(int productId);

        void DeleteProduct(int productId);

        IEnumerable<Product> ViewProductsByCategoryId(int categoryId);
    }
}
