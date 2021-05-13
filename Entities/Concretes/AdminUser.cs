using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concretes
{
    public class AdminUser:User,IEntity
    {
        public int UserId { get; set; }
    }
}
