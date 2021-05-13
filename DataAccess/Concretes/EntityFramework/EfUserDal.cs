using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, iMusicDbContext>, IUserDal
    {
        public List<Core.Entities.Concrete.OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }
    }
}
