using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Implementations;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.BussinessLogic.Services.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            this._artistRepository = artistRepository;
        }

        public IEnumerable<Artist> GetAll()
        {
            return _artistRepository.GetAll();
        }

        public Artist Get(ObjectId id)
        {
            return _artistRepository.GetById(id);
        }

        public void Create(Artist artist)
        {
            _artistRepository.Create(artist);
        }

        public bool Update(ObjectId id, Artist artist)
        {
            return _artistRepository.Update(id, artist);
        }

        public bool Delete(ObjectId id)
        {
            return _artistRepository.Delete(id);
        }
    }
}
