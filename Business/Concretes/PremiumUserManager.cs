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
    public class PremiumUserManager : IPremiumUserService
    {
        IPremiumUserDal _premiumUserDal;

        public PremiumUserManager(IPremiumUserDal premiumUserDal)
        {
            _premiumUserDal = premiumUserDal;
        }

        public IResult AddPremiumUser(PremiumUser premiumUser)
        {
            _premiumUserDal.Add(premiumUser);
            return new SuccessResult();
        }

        public IResult DeletePremiumUser(PremiumUser premiumUser)
        {
            _premiumUserDal.Update(premiumUser);
            return new SuccessResult();
        }

        public IDataResult<List<PremiumUser>> GetAll()
        {
            return new SuccessDataResult<List<PremiumUser>>(_premiumUserDal.GetAll());
        }

        public IDataResult<List<OperationClaim>> GetClaims(PremiumUser premiumUser)
        {
            return new SuccessDataResult<List<OperationClaim>>(_premiumUserDal.GetClaims(premiumUser));
        }

        public IResult UpdatePremiumUser(PremiumUser premiumUser)
        {
            _premiumUserDal.Update(premiumUser);
            return new SuccessResult();
        }
    }
}
