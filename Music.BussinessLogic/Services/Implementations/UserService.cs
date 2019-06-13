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
    public class UserService : IUserService
    {
        private readonly IUserRepository _authRepository;
        
        public UserService(IUserRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        #region SyncCRUD

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

        #endregion

        #region AsyncCRUD

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _authRepository.GetAllAsync();
        }

        public async Task<User> GetAsync(ObjectId id)
        {
            return await _authRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(User user)
        {
            await _authRepository.CreateAsync(user);
        }

        public async Task<bool> UpdateAsync(ObjectId id, User user)
        {
            return await _authRepository.UpdateAsync(id, user);
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            return await _authRepository.DeleteAsync(id);
        }

        #endregion
        
        public async Task<User> GetUser(string login, string password)
        {
            return await _authRepository.GetUser(login, password);
        }
    }
}
