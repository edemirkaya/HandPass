using HandPass.Core.Abstraction.Entity;

namespace HandPass.Entities.Dto
{
    public class UserForLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
