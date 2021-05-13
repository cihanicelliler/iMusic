using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfPremiumUserDal : EfEntityRepositoryBase<PremiumUser, iMusicDbContext>, IPremiumUserDal
    {
        public List<OperationClaim> GetClaims(PremiumUser premiumUser)
        {
            throw new NotImplementedException();
        }
    }
}
