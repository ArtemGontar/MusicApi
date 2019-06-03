using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Music.DataAccess.Entities;

namespace Music.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUser(string login, string password);
    }
}
