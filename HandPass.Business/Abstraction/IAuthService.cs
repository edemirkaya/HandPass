using HandPass.Core.Abstraction.Utility;
using HandPass.Core.CoreEntities;
using HandPass.Core.Utilities.Security.Jwt;
using HandPass.Entities.Dto;

namespace HandPass.Business.Abstraction
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
