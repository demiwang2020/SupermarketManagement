using CoreBusiness;

namespace UserCases.UseCaseInterfaces
{
    public interface IGetProductByIdUseCase
    {
        Product Execute(int productId);
    }
}