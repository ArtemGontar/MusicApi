using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Impementations;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.DataAccess.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<Settings> settings)
            : base(settings, nameof(User))
        {
        }
        public async Task<User> GetUser(string login, string password)
        {
            return await _collection.Find(x => x.Login == login && x.Password == password)
                .FirstOrDefaultAsync();
        }
        
    }
}
