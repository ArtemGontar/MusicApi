using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
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

        public Song Get(int id)
        {
            return _songRepository.GetById(id);
        }

        public void Create(Song song)
        {
            _songRepository.Create(song);
        }

        public bool Update(int id, Song song)
        {
            return _songRepository.Update(id, song);
        }

        public bool Delete(int id)
        {
            return _songRepository.Delete(id);
        }
    }
}
