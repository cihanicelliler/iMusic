using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concretes
{
    public class Artist:IEntity
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string CountryCode { get; set; }
    }
}
