using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concretes
{
    public class Album : IEntity
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public int CategoryId { get; set; }
        public int MusicId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumDate { get; set; }
    }
}
