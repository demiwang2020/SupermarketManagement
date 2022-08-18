using CoreBusiness;
using UserCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {

        private List<Category> categories;
        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category{ CategoryId=1,Name="Beverage",Description="Beverage"},

                new Category{ CategoryId=2,Name="Bakery",Description="Bakery"},

                new Category{ CategoryId=3,Name="Meat",Description="Meat"},
            };     
            
            
          }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else {
                category.CategoryId = 1;
            }
            
            categories.Add(category);
        }

        public void DeleteCategory(int CategoryId)
        {
            var DeleteCategory = GetCategoryById(CategoryId);
            categories?.Remove(DeleteCategory);
        }
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null) {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
                return categoryToUpdate;
            }
            return null;
        }
        public Category GetCategoryById(int categoryId)
        {
            return categories.FirstOrDefault(x => x.CategoryId == categoryId);
           
        }
    }
}