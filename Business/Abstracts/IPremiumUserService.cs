using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IPremiumUserService
    {
        IDataResult<List<PremiumUser>> GetAll();
        IResult AddPremiumUser(PremiumUser premiumUser);
        IResult DeletePremiumUser(PremiumUser premiumUser);
        IResult UpdatePremiumUser(PremiumUser premiumUser);
        IDataResult<List<OperationClaim>> GetClaims(PremiumUser premiumUser);
    }
}
