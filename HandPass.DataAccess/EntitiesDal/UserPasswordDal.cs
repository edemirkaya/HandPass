using HandPass.Core.CoreDataAccess;
using HandPass.DataAccess.Abstraction;
using HandPass.Entities.Entitiy;

namespace HandPass.DataAccess.EntitiesDal
{
    public class UserPasswordDal : EntityRepositoryBase<UserPassword,HandPassContext>,IUserPasswordDal
    { }
}
