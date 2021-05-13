using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IMusicService
    {
        IDataResult<List<Music>> GetAll();
        IResult AddMusic(Music music);
        IResult DeleteMusic(Music music);
        IResult UpdateMusic(Music music);
        IDataResult<List<Music>> GetById(int musicId);
        IDataResult<List<Music>> GetByArtistId(int id);
        IDataResult<List<Music>> GetByCategoryId(int id);
        IDataResult<List<Music>> GetAlbumId(int id);
    }
}
