using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class ArtistManager : IArtistService
    {
        IArtistDal _artistDal;

        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
        }

        public IResult AddArtist(Artist artist)
        {
            _artistDal.Add(artist);
            return new SuccessResult();
        }

        public IResult DeleteArtist(Artist artist)
        {
            _artistDal.Delete(artist);
            return new SuccessResult();
        }

        public IDataResult<List<Artist>> GetAll()
        {
            return new SuccessDataResult<List<Artist>>(_artistDal.GetAll());
        }

        public IDataResult<List<Artist>> GetById(int artistId)
        {
            return new SuccessDataResult<List<Artist>>(_artistDal.GetAll(a=>a.ArtistId==artistId));
        }

        public IResult UpdateArtist(Artist artist)
        {
            _artistDal.Update(artist);
            return new SuccessResult();
        }
    }
}
