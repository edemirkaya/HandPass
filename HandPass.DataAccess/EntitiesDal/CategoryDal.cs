using HandPass.Core.CoreDataAccess;
using HandPass.DataAccess.Abstraction;
using HandPass.Entities.Entitiy;

namespace HandPass.DataAccess.EntitiesDal
{
    public class CategoryDal : EntityRepositoryBase<Category, HandPassContext>, ICategoryDal
    {
    }
}
