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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this._groupRepository = groupRepository;
        }

        #region SyncCRUD

        public IEnumerable<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group Get(ObjectId id)
        {
            return _groupRepository.GetById(id);
        }

        public void Create(Group group)
        {
            _groupRepository.Create(group);
        }

        public bool Update(ObjectId id, Group group)
        {
            return _groupRepository.Update(id, group);
        }

        public bool Delete(ObjectId id)
        {
            return _groupRepository.Delete(id);
        }

        #endregion

        #region AsyncCRUD

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _groupRepository.GetAllAsync();
        }

        public async Task<Group> GetAsync(ObjectId id)
        {
            return await _groupRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Group group)
        {
            await _groupRepository.CreateAsync(group);
        }

        public async Task<bool> UpdateAsync(ObjectId id, Group group)
        {
            return await _groupRepository.UpdateAsync(id, group);
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            return await _groupRepository.DeleteAsync(id);
        }

        #endregion

    }
}
