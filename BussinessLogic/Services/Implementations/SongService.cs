using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;

namespace BussinessLogic.Services.Implementations
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            this._songRepository = songRepository;
        }

        public IEnumerable<Song> GetAll()
        {
            return _songRepository.GetAll();
        }

        public Song Get(ObjectId id)
        {
            return _songRepository.GetById(id);
        }

        public void Create(Song song)
        {
            _songRepository.Create(song);
        }

        public bool Update(ObjectId id, Song song)
        {
            return _songRepository.Update(id, song);
        }

        public bool Delete(ObjectId id)
        {
            return _songRepository.Delete(id);
        }
    }
}
