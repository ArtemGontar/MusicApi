using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.DataAccess.Entities;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IAlbumService : IService
    {
        IEnumerable<Album> GetAll();

        Album Get(ObjectId id);

        void Create(Album album);

        bool Update(ObjectId id, Album album);

        bool Delete(ObjectId id);
    }
}
