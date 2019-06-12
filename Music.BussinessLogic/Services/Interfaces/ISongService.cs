using Music.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface ISongService : IService<Song>
    {
    }
}
