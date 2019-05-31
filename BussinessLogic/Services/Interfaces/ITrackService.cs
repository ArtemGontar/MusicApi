using Music.DataAccess.Entities;
using System.Collections.Generic;

namespace BussinessLogic.Services.Interfaces
{
    public interface ITrackService : IService
    {
        IEnumerable<Track> GetAll();
    }
}
