using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;

namespace UserCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        void Save(string cashierName,int productId,double price,int beforeQty,int soldQty,string productName);
        IEnumerable<Transaction> GetByDay(string cashierName,DateTime date);
        IEnumerable<Transaction> Search(string cashierName, DateTime startDate,DateTime endTime);
    }
}
