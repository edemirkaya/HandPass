using HandPass.Core.Abstraction.Entity;
using HandPass.Core.CoreEntities;

namespace HandPass.Entities.Entitiy
{
    public class UserPassword : BaseEntity, IEntity
    {
        public string PassDefinition { get; set; }
        public string Url { get; set; }
        public int PassCategory { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
