using HandPass.Business.Abstraction;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.CoreEntities;
using HandPass.Core.Utilities.Results;
using HandPass.DataAccess.Abstraction;

namespace HandPass.Business.Manager
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            var data = _userDal.GetByConditions(u => u.UserName == userName);

            return new DataResult<User>(data,true);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var data = _userDal.GetClaims(user);
            return new DataResult<List<OperationClaim>>(data,true);
        }
    }
}
