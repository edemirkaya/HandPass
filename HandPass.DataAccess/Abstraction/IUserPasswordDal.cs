using HandPass.Core.Abstraction.Repository;
using HandPass.Entities.Entitiy;

namespace HandPass.DataAccess.Abstraction
{
    public interface IUserPasswordDal : IEntityRepository<UserPassword>
    {
    }
}
