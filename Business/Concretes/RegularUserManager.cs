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
    public class RegularUserManager : IRegularUserService
    {
        IRegularUserDal _regularUserDal;

        public RegularUserManager(IRegularUserDal regularUserDal)
        {
            _regularUserDal = regularUserDal;
        }

        public IResult AddRegularUser(RegularUser regularUser)
        {
            _regularUserDal.Add(regularUser);
            return new SuccessResult();
        }

        public IResult DeleteRegularUser(RegularUser regularUser)
        {
            _regularUserDal.Delete(regularUser);
            return new SuccessResult();
        }

        public IDataResult<List<RegularUser>> GetAll()
        {
            return new SuccessDataResult<List<RegularUser>>(_regularUserDal.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(RegularUser regularUser)
        {
            return new SuccessDataResult<List<OperationClaim>>(_regularUserDal.GetClaims(regularUser));
        }

        public IResult UpdateRegularUser(RegularUser regularUser)
        {
            _regularUserDal.Update(regularUser);
            return new SuccessResult();
        }
    }
}
