using Business.Abstracts;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(Entities.Concretes.User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult DeleteUser(Entities.Concretes.User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<Entities.Concretes.User>> GetAll()
        {
            return new SuccessDataResult<List<Entities.Concretes.User>>(_userDal.GetAll());
        }

        public IDataResult<Entities.Concretes.User> GetByMail(string email)
        {
            return new SuccessDataResult<Entities.Concretes.User>(_userDal.Get(u=>u.UserEmail==email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(Entities.Concretes.User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult UpdateUser(Entities.Concretes.User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
