using HandPass.Business.Abstraction;
using HandPass.Business.Constants;
using HandPass.Core.Abstraction.Abstract;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Aspects.Autofac.Caching;
using HandPass.Core.CoreEntities;
using HandPass.Core.Utilities.Results;
using HandPass.DataAccess.Abstraction;
using HandPass.Entities.Entitiy;

namespace HandPass.Business.Manager
{
    public class UserPasswordManager : IUserPasswordService
    {
        private IUserPasswordDal _userPasswordDal;
        private ICacheManager _cacheManager;
        public UserPasswordManager(IUserPasswordDal userPasswordDal, ICacheManager cacheManager)
        {
            _userPasswordDal = userPasswordDal;
            _cacheManager = cacheManager;
        }

        public void Add(UserPassword userPassword)
        {
            _userPasswordDal.Add(userPassword);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<UserPassword>> GetUserAllPasswords()
        {
            var  currentUser= _cacheManager.Get<User>("currentUser");
            var data = _userPasswordDal.GetAll(u => u.Id == currentUser.Id).ToList();
            if (data == null)
            {
                return new ErrorDataResult<List<UserPassword>>(Messages.UserNotFound);
            }
            return new SuccessDataResult<List<UserPassword>>(data, Messages.Success);
        }
    }
}
