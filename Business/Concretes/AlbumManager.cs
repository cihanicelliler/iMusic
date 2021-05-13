using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class AlbumManager : IAlbumService
    {
        IAlbumDal _albumDal;

        public AlbumManager(IAlbumDal albumDal)
        {
            _albumDal = albumDal;
        }

        public IResult AddAlbum(Album album)
        {
            _albumDal.Add(album);
            return new SuccessResult();
        }

        public IResult DeleteAlbum(Album album)
        {
            _albumDal.Delete(album);
            return new SuccessResult();
        }

        public IDataResult<List<Album>> GetAll()
        {
            return new SuccessDataResult<List<Album>>(_albumDal.GetAll());
        }

        public IDataResult<List<Album>> GetByArtistId(int id)
        {
            return new SuccessDataResult<List<Album>>(_albumDal.GetAll(a=>a.ArtistId==id));
        }

        public IDataResult<List<Album>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Album>>(_albumDal.GetAll(a=>a.CategoryId==id));
        }

        public IDataResult<List<Album>> GetById(int albumId)
        {
            return new SuccessDataResult<List<Album>>(_albumDal.GetAll(a=>a.AlbumId== albumId));
        }

        public IDataResult<List<Album>> GetMusicId(int id)
        {
            return new SuccessDataResult<List<Album>>(_albumDal.GetAll(a => a.MusicId == id));
        }

        public IResult UpdateAlbum(Album album)
        {
            _albumDal.Update(album);
            return new SuccessResult();
        }
    }
}
