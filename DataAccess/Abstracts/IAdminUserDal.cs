using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstracts
{
    public interface IAdminUserDal :IEntityRepository<AdminUser>
    {
        List<OperationClaim> GetClaims(AdminUser adminUser);
    }
}
