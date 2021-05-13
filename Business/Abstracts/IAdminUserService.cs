using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IAdminUserService
    {
        IDataResult<List<AdminUser>> GetAll();
        IResult AddAdminUser(AdminUser adminUser);
        IResult DeleteAdminUser(AdminUser adminUser);
        IResult UpdateAdminUser(AdminUser adminUser);
        IDataResult<List<OperationClaim>> GetClaims(AdminUser adminUser);
    }
}
