using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.BussinessLogic.Services.Implementations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }

        #region SyncCRUD

        public IEnumerable<Album> GetAll()
        {
            return _albumRepository.GetAll();
        }

        public Album Get(ObjectId id)
        {
            return _albumRepository.GetById(id);
        }

        public void Create(Album album)
        {
            _albumRepository.Create(album);
        }

        public bool Update(ObjectId id, Album album)
        {
            return _albumRepository.Update(id, album);
        }

        public bool Delete(ObjectId id)
        {
            return _albumRepository.Delete(id);
        }

        #endregion

        #region ÁsyncCRUD

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _albumRepository.GetAllAsync();
        }

        public async Task<Album> GetAsync(ObjectId id)
        {
            return await _albumRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Album album)
        {
            await _albumRepository.CreateAsync(album);
        }

        public async Task<bool> UpdateAsync(ObjectId id, Album album)
        {
            return await _albumRepository.UpdateAsync(id, album);
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            return await _albumRepository.DeleteAsync(id);
        }

        #endregion

    }
}
