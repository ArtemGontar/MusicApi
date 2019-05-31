using Music.DataAccess.Entities;
using System.Collections.Generic;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface ISongService : IService
    {
        IEnumerable<Song> GetAll();

        Song Get(int id);

        void Create(Song song);

        bool Update(int id, Song song);

        bool Delete(int id);
    }
}
