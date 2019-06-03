using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Music.DataAccess.Entities;

namespace Music.DataAccess.Repositories.Interfaces
{
    public interface IAuthRepository : IGenericRepository<User>
    {
        Task<User> GetUser(string login, string password);
    }
}
