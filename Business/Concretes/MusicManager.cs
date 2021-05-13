using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class MusicManager : IMusicService
    {
        IMusicDal _musicDal;

        public MusicManager(IMusicDal musicDal)
        {
            _musicDal = musicDal;
        }

        public IResult AddMusic(Music music)
        {
            _musicDal.Add(music);
            return new SuccessResult();
        }

        public IResult DeleteMusic(Music music)
        {
            _musicDal.Delete(music);
            return new SuccessResult();
        }

        public IDataResult<List<Music>> GetAlbumId(int id)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(m => m.AlbumId == id));
        }

        public IDataResult<List<Music>> GetAll()
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll());
        }

        public IDataResult<List<Music>> GetByArtistId(int id)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(m => m.ArtistId == id));
        }

        public IDataResult<List<Music>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(m => m.CategoryId == id));
        }

        public IDataResult<List<Music>> GetById(int musicId)
        {
            return new SuccessDataResult<List<Music>>(_musicDal.GetAll(m => m.MusicId == musicId));
        }

        public IResult UpdateMusic(Music music)
        {
            _musicDal.Update(music);
            return new SuccessResult();
        }
    }
}
