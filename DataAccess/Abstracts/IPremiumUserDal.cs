using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstracts
{
    public interface IPremiumUserDal : IEntityRepository<PremiumUser>
    {
        List<OperationClaim> GetClaims(PremiumUser premiumUser);
    }
}
