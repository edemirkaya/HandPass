using HandPass.Business.Abstraction;
using HandPass.Core.Abstraction.Abstract;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Utilities.Results;
using HandPass.DataAccess.Abstraction;
using HandPass.Entities.Entitiy;

namespace HandPass.Business.Manager
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private ICacheManager _cacheManager;

        public CategoryManager(ICategoryDal categoryDal, ICacheManager cacheManager)
        {
            _categoryDal = categoryDal;
            _cacheManager = cacheManager;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
            _cacheManager.Remove("Categories");
        }

        public IDataResult<List<Category>> GetList()
        {
            if (_cacheManager.isAdd("Categories"))
            {
                return new SuccessDataResult<List<Category>>(_cacheManager.Get<List<Category>>("Categories"));
            }
            List<Category> list = new List<Category>(_categoryDal.GetAll());
            _cacheManager.Add("Categories",list,10);
            return new SuccessDataResult<List<Category>>(list);
        }
    }
}
