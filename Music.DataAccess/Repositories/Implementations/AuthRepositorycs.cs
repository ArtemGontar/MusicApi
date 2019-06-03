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
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        public AuthRepository(IOptions<Settings> settings)
            : base(settings, nameof(User))
        {
        }
        //public AuthRepository(IOptions<Settings> settings)
        //{
        //    _context = new AuthContext(settings);
        //}
        public async Task<User> GetUser(string login, string password)
        {
            var builder = Builders<User>.Filter;
            var filter = builder.Eq("Login", login) & builder.Eq("Password", password);

            return await _collection.Find(filter)
                .FirstOrDefaultAsync();
        }
    }
}
