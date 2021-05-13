using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IAlbumService
    {
        IDataResult<List<Album>> GetAll();
        IResult AddAlbum(Album album);
        IResult DeleteAlbum(Album album);
        IResult UpdateAlbum(Album album);
        IDataResult<List<Album>> GetById(int albumId);
        IDataResult<List<Album>> GetByArtistId(int id);
        IDataResult<List<Album>> GetByCategoryId(int id);
        IDataResult<List<Album>> GetMusicId(int id);
    }
}
