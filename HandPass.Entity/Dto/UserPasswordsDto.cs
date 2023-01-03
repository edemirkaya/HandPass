using HandPass.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandPass.Entities.Dto
{
    public class UserPasswordsDto
    {
        public string PassDefinition { get; set; }
        public string Url { get; set; }
        public int PassCategory { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
