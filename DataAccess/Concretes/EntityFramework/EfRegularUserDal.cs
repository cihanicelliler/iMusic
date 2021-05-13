using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRegularUserDal : EfEntityRepositoryBase<RegularUser, iMusicDbContext>, IRegularUserDal
    {
        public List<OperationClaim> GetClaims(RegularUser regularUser)
        {
            throw new NotImplementedException();
        }
    }
}
