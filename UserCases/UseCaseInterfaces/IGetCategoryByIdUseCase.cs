using CoreBusiness;

namespace UserCases.UseCaseInterfaces
{
    public interface IGetCategoryByIdUseCase
    {
        Category Execute(int categoryId);
    }
}