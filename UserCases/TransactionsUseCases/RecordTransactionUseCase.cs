﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCases.DataStorePluginInterfaces;
using UserCases.UseCaseInterfaces;

namespace UserCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductByIdUseCase getProductByIdUseCase;
        public RecordTransactionUseCase(ITransactionRepository transactionRepository,
            IGetProductByIdUseCase getProductByIdUseCase)
        {
            this.transactionRepository = transactionRepository;
            GetProductByIdUseCase = getProductByIdUseCase;
        }

        public IGetProductByIdUseCase GetProductByIdUseCase { get; }

        public void Execute(string cashierName, int productId,int soldQty)
        {
            var product = getProductByIdUseCase.Execute(productId);
            transactionRepository.Save(cashierName, productId, product.Price, product.Quantity, soldQty,product.Name);
        }
    }
}
