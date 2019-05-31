using System;
using System.Collections.Generic;
using System.Text;
using Music.DataAccess.Entities;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IArtistService : IService
    {
        IEnumerable<Artist> GetAll();

        Artist Get(int id);

        void Create(Artist artist);

        bool Update(int id, Artist artist);

        bool Delete(int id);
    }
}
