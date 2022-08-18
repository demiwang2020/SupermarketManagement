using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
         IEnumerable<Category> GetCategories();
         void AddCategory(Category category);

         Category UpdateCategory(Category category);

        Category GetCategoryById(int categoryId);

        void DeleteCategory(int categoryId);
    }
}
