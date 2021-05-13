using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concretes
{
    public class PremiumUser:User,IEntity
    {
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
    }
}
