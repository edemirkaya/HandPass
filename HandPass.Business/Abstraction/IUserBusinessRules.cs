using HandPass.Core.Abstraction.Utility;

namespace HandPass.Business.Abstraction
{
    public interface IUserBusinessRules
    {
        public IResult CheckUserNameExist(string userName);
    }
}
