using HandPass.Core.Abstraction.Utility;
using HandPass.Core.CoreEntities;
using HandPass.DataAccess.Abstraction;
using HandPass.Entities.Dto;
using HandPass.Entities.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandPass.Business.Abstraction
{
    public interface IUserPasswordService
    {
        IDataResult<List<UserPassword>> GetUserAllPasswords();
        void Add(UserPassword userPassword);
    }
}
