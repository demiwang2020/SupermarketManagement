namespace UserCases.UseCaseInterfaces
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId,int soldQty);
    }
}