using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfAdminUserDal : EfEntityRepositoryBase<AdminUser, iMusicDbContext>, IAdminUserDal
    {
        public List<OperationClaim> GetClaims(AdminUser adminUser)
        {
            throw new NotImplementedException();
        }
    }
}
