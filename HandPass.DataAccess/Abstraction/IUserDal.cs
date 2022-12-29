using HandPass.Core.Abstraction.Repository;
using HandPass.Core.CoreEntities;

namespace HandPass.DataAccess.Abstraction
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
