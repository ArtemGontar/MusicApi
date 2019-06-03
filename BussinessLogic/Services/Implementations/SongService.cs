using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        #region SyncCRUD

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

        #endregion
        
        #region AsyncCRUD

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _songRepository.GetAllAsync();
        }

        public async Task<Song> GetAsync(ObjectId id)
        {
            return await _songRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Song song)
        {
            await _songRepository.CreateAsync(song);
        }

        public async Task<bool> UpdateAsync(ObjectId id, Song song)
        {
            return await _songRepository.UpdateAsync(id, song);
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            return await _songRepository.DeleteAsync(id);
        }

        #endregion
    }
}
