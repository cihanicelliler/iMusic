using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstracts
{
    public interface IUserDal:IEntityRepository<Entities.Concretes.User>
    {
        List<OperationClaim> GetClaims(Entities.Concretes.User user);
    }
}
