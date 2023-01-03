using HandPass.Core.CoreEntities;

namespace HandPass.WebUI.Models
{
    public class UserPasswordViewModel
    {
        public string PassDefinition { get; set; }
        public string Url { get; set; }
        public string PassCategory { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
