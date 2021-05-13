using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IUserService
    {
        IDataResult<List<Entities.Concretes.User>> GetAll();
        IResult AddUser(Entities.Concretes.User user);
        IResult DeleteUser(Entities.Concretes.User user);
        IResult UpdateUser(Entities.Concretes.User user);
        IDataResult<List<OperationClaim>> GetClaims(Entities.Concretes.User user);
        IDataResult<Entities.Concretes.User> GetByMail(string email);
    }
}
