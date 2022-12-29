using HandPass.Core.Abstraction.Utility;
using HandPass.Core.CoreEntities;

namespace HandPass.Business.Abstraction
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        void Add(User user);
        IDataResult<User> GetByUserName(string userName);
    }
}
