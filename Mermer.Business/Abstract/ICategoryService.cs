using System.Collections.Generic;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Abstract
{
    public interface ICategoryService
    {
        string GetCategoriesJson();
        bool UpdateCategory(Category model);
        void RemoveOrder(int id);
        bool AddCategory(Category model);
        List<Category> GetCategories();
        Category GetCategoryById(int id);
    }
}