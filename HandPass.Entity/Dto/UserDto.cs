using HandPass.Core.Abstraction.Entity;

namespace HandPass.Entities.Dto
{
    public class UserDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
