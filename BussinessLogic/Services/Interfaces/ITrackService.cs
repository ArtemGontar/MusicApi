using System;
using System.Collections.Generic;
using System.Text;
using Music.DataAccess.Entities;

namespace BussinessLogic.Services.Interfaces
{
    public interface ITrackService : IService
    {
        IEnumerable<Track> GetAll();
    }
}
