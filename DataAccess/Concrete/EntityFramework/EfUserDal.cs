using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, KayraExportContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new KayraExportContext())
        {
            var result = from opetionClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationsClaims
                         on opetionClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.UserId
                         select new OperationClaim { OperationClaimId = opetionClaim.OperationClaimId, Name = opetionClaim.Name };
            return result.ToList();
        }
    }
}
