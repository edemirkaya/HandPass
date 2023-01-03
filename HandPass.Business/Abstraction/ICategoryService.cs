using HandPass.Core.Abstraction.Utility;
using HandPass.Core.CoreEntities;
using HandPass.Entities.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandPass.Business.Abstraction
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();
        void Add(Category category);
    }
}
