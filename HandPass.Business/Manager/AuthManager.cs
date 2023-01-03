using HandPass.Business.Abstraction;
using HandPass.Business.Constants;
using HandPass.Core.Abstraction.Abstract;
using HandPass.Core.Abstraction.Utility;
using HandPass.Core.Aspects.Autofac.Caching;
using HandPass.Core.CoreEntities;
using HandPass.Core.Utilities.Results;
using HandPass.Core.Utilities.Security.Hashing;
using HandPass.Core.Utilities.Security.Jwt;
using HandPass.Entities.Dto;

namespace HandPass.Business.Manager
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private ICacheManager _cacheManager;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICacheManager cacheManager)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _cacheManager = cacheManager;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUserName(userForLoginDto.UserName);
            
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            _cacheManager.Add("currentUser", userToCheck.Data, 10);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.Success);
        }

        public IResult UserExists(string userName)
        {
            if (_userService.GetByUserName(userName).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
