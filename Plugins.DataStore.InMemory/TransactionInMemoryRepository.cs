using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions=new List<Transaction>();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            

                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            
            else 

                return transactions.Where(x=>string.Equals(x.CashierName,cashierName,StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp.Date==date.Date);
            
        }

        public void Save(string cashierName,int productId, double price, int beforeQty,int soldQty,string  productName)
        {
            var transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.TransactionId);

                transactionId = maxId + 1;
            }
            else {
                transactionId = 1;
            }


            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName,
                ProductName = productName
            }) ; 
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endTime)
        {
            if (string.IsNullOrWhiteSpace(cashierName))


                return transactions.Where(x => x.TimeStamp.Date >= startDate.Date&& x.TimeStamp.Date <= endTime.Date.AddDays(1).Date);

            else

                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)
                && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endTime.Date.AddDays(1).Date);
        }
    }
}
