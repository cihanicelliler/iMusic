using Business.Abstracts;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class AdminUserManager : IAdminUserService
    {
        IAdminUserDal _adminUserDal;

        public AdminUserManager(IAdminUserDal adminUserDal)
        {
            _adminUserDal = adminUserDal;
        }

        public IResult AddAdminUser(AdminUser adminUser)
        {
            _adminUserDal.Add(adminUser);
            return new SuccessResult();
        }

        public IResult DeleteAdminUser(AdminUser adminUser)
        {
            _adminUserDal.Delete(adminUser);
            return new SuccessResult();
        }

        public IDataResult<List<AdminUser>> GetAll()
        {
            return new SuccessDataResult<List<AdminUser>>(_adminUserDal.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(AdminUser adminUser)
        {
            return new SuccessDataResult<List<OperationClaim>>(_adminUserDal.GetClaims(adminUser));
        }

        public IResult UpdateAdminUser(AdminUser adminUser)
        {
            _adminUserDal.Update(adminUser);
            return new SuccessResult();
        }
    }
}
