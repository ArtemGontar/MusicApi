using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Music.DataAccess.Entities;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IUserService : IService
    {
        IEnumerable<User> GetAll();

        User Get(ObjectId id);

        void Create(User user);

        bool Update(ObjectId id, User user);

        bool Delete(ObjectId id);

        Task<User> GetUser(string login, string password);
    }
}
