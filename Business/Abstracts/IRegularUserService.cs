using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IRegularUserService
    {
        IDataResult<List<RegularUser>> GetAll();
        IResult AddRegularUser(RegularUser regularUser);
        IResult DeleteRegularUser(RegularUser regularUser);
        IResult UpdateRegularUser(RegularUser regularUser);
        IDataResult<List<OperationClaim>> GetClaims(RegularUser regularUser);
    }
}
