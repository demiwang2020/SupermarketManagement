using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCases.DataStorePluginInterfaces;
using UserCases.UseCaseInterfaces;

namespace UserCases.CategroiesUseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category Execute(Category category)
        {

            return categoryRepository.UpdateCategory(category);
        }

    }
}
