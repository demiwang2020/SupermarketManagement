using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly MarketContext db;

        public CategoryRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category=db.Categories.Find(categoryId);
            if (category!=null) {

                db.Categories.Remove(category);
            }
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Categories.Find(categoryId);
        }

        public Category UpdateCategory(Category category)
        {
            var cate= db.Categories.Find(category.CategoryId);
            cate.Name = category.Name; 
            cate.Description=category.Description;
            return cate;
            db.SaveChanges();
        }
    }
}
