﻿using HandPass.Core.CoreDataAccess;
using HandPass.Core.CoreEntities;
using HandPass.DataAccess.Abstraction;

namespace HandPass.DataAccess.EntitiesDal
{
    public class UserDal : EntityRepositoryBase<User, HandPassContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new HandPassContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
