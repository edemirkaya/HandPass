using HandPass.Business.Abstraction;
using HandPass.Business.Constants;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Utilities.Results;
using HandPass.DataAccess.Abstraction;

namespace HandPass.Business.ConditionRules
{
    public class UserBusinessRules : IUserBusinessRules
    {
        IUserDal _userDal;

        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult CheckUserNameExist(string userName)
        {
            var result = _userDal.GetByConditions(x => x.UserName == userName);
            if (result == null)
                return new ErrorResult(Messages.DuplicateUserNameError);
            return new SuccessResult();
        }
    }
}
