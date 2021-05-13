using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concretes
{
    public class Music : IEntity
    {
        public int MusicId { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int CategoryId { get; set; }
        public string MusicName { get; set; }
        public DateTime MusicDate { get; set; }
        public int Time { get; set; }
        public int ListeningCount { get; set; }
    }
}
