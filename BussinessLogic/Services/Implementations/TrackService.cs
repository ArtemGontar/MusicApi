using BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace BussinessLogic.Services.Implementations
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            this._trackRepository = trackRepository;
        }

        public IEnumerable<Track> GetAll()
        {
            return _trackRepository.GetAll();
        }
    }
}
