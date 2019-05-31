using System;
using System.Collections.Generic;
using System.Text;
using BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Implementations;
using Music.DataAccess.Repositories.Interfaces;

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
