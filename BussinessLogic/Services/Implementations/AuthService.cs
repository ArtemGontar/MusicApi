using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.BussinessLogic.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _authRepository.GetAll();
        }

        public User Get(ObjectId id)
        {
            return _authRepository.GetById(id);
        }

        public void Create(User user)
        {
            _authRepository.Create(user);
        }

        public bool Update(ObjectId id, User user)
        {
            return _authRepository.Update(id, user);
        }

        public bool Delete(ObjectId id)
        {
            return _authRepository.Delete(id);
        }

        public async Task<User> GetUser(string login, string password)
        {
            return await _authRepository.GetUser(login, password);
        }
    }
}
