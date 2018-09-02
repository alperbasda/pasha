using System.Collections.Generic;
using Mermer.Business.Abstract;
using Mermer.Core.Aspects.AuthorizationAspects;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public string GetCategoriesJson()
        {
            return _categoryDal.GetCategoriesJson();
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public bool UpdateCategory(Category model)
        {
            _categoryDal.Update(model);
            return true;
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public void RemoveOrder(int id)
        {
            _categoryDal.Delete(_categoryDal.Get(s => s.Id == id));
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public bool AddCategory(Category model)
        {
            _categoryDal.Add(model);
            return true;
        }
        public List<Category> GetCategories()
        {
            return _categoryDal.GetList();
        }
        [SecuredOperationAspect(Roles = "Admin")]
        public Category GetCategoryById(int id)
        {
            return _categoryDal.Get(s => s.Id == id);
        }
    }
}