using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UserCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))


                return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);

            else

                return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%")
                 && x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, double price, int beforeQty, int soldQty, string productName)
        {
            var transaction = new Transaction {
                ProductId = productId,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName,
                ProductName = productName
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
;        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endTime)
        {
            if (string.IsNullOrWhiteSpace(cashierName))


                return db.Transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endTime.Date.AddDays(1).Date);

            else

                return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%")
                && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endTime.Date.AddDays(1).Date);
        }
    
    }
}
