using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCases.DataStorePluginInterfaces;
using UserCases.UseCaseInterfaces;

namespace UserCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly ITransactionRepository transactionRepository;

        public SellProductUseCase(IProductRepository productRepository,
            ITransactionRepository transactionRepository)
        {
            this.productRepository = productRepository;
            this.transactionRepository = transactionRepository;
        }
        public void Execute(string cashierName,int productId, int beforeQty,int qtyToSell)
        {

            var product = productRepository.GetProductById(productId);
            var product1 = productRepository.GetProductById(productId);
            if (product == null) return;
            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(product);
            transactionRepository.Save(cashierName,productId, product.Price, beforeQty,qtyToSell, product.Name);
        }


    }
}
