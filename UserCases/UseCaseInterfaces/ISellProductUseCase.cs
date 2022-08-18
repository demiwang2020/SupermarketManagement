namespace UserCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName,int productId, int beforeQty,int qtyToSell);
    }
}