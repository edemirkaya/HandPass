using HandPass.Business.Abstraction;
using HandPass.Core.CoreEntities;
using Microsoft.AspNetCore.Mvc;

namespace HandPass.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public User AddUser(User user)
        {
            _userService.Add(user);
            return user;
        }

        [HttpGet("GetByUserName")]
        public User GetByUserName(string userName) { 
        return _userService.GetByUserName(userName).Data;
        }   
        
        [HttpGet("GetByCacheUserName")]
        public User GetByCacheUserName() { 
        return _userService.GetByCacheUserName().Data;
        }   
    }
}
