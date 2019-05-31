using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
