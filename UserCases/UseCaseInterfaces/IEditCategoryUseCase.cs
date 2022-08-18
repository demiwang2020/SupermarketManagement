using CoreBusiness;

namespace UserCases.UseCaseInterfaces
{
    public interface IEditCategoryUseCase
    {
        Category Execute(Category category);
    }
}