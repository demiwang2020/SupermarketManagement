using CoreBusiness;

namespace UserCases.UseCaseInterfaces
{
    public interface IGetTodayTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}