using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Music.DataAccess.Entities;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IAlbumService : IService<Album>
    {
    }
}
