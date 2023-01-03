using HandPass.Business.Abstraction;
using HandPass.Entities.Dto;
using HandPass.Entities.Entitiy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HandPass.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPasswordController : ControllerBase
    {
        private IUserPasswordService _service;

        public UserPasswordController(IUserPasswordService service)
        {
            _service = service;
        }

        [HttpGet("GetUserAllPasswords")]
        public ActionResult GetUserAllPasswords()
        {
            var result = _service.GetUserAllPasswords();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
                return Ok(result);
        }
        
        [HttpPost("NewUserPassword")]
        public void NewUserPassword(UserPassword model)
        {
            _service.Add(model);
        }
    }
}
