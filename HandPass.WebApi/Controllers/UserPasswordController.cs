using Microsoft.AspNetCore.Mvc;

namespace HandPass.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPasswordController : ControllerBase
    {
        private readonly ILogger<UserPasswordController> _logger;

        public UserPasswordController(ILogger<UserPasswordController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public string Get()
        {
            return "Merhaba";
        }
    }
}
