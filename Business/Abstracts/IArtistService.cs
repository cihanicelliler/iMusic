using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IArtistService
    {
        IDataResult<List<Artist>> GetAll();
        IResult AddArtist(Artist artist);
        IResult DeleteArtist(Artist artist);
        IResult UpdateArtist(Artist artist);
        IDataResult<List<Artist>> GetById(int artistId);
    }
}
