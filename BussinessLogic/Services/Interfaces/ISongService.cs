using Music.DataAccess.Entities;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface ISongService : IService
    {
        IEnumerable<Song> GetAll();

        Song Get(ObjectId id);

        void Create(Song song);

        bool Update(ObjectId id, Song song);

        bool Delete(ObjectId id);
    }
}
