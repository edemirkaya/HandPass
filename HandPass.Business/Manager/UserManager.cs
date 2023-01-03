using HandPass.Business.Abstraction;
using HandPass.Business.Constants;
using HandPass.Core.Abstraction.Abstract;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Aspects.Autofac.Caching;
using HandPass.Core.CoreEntities;
using HandPass.Core.Utilities.Results;
using HandPass.DataAccess.Abstraction;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HandPass.Business.Manager
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        private ICacheManager _cacheManager;
        public UserManager(IUserDal userDal, ICacheManager cacheManager)
        {
            _userDal = userDal;
            _cacheManager = cacheManager;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<User> GetByCacheUserName()
        {
            User user = _cacheManager.Get<User>("currentUser");
            var data = _userDal.GetByConditions(u => u.UserName == user.UserName);
            if (data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(data, Messages.Success);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<User> GetByUserName(string userName)
        {
            var data = _userDal.GetByConditions(u => u.UserName == userName);
            if (data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            _cacheManager.Add("currentUser", data, 10);
            return new SuccessDataResult<User>(data, Messages.Success);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var data = _userDal.GetClaims(user);
            return new DataResult<List<OperationClaim>>(data,true);
        }
    }
}
