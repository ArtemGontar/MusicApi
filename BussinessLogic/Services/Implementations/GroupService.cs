using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.BussinessLogic.Services.Interfaces;
using Music.DataAccess.Entities;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.BussinessLogic.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _songRepository;

        public GroupService(IGroupRepository songRepository)
        {
            this._songRepository = songRepository;
        }

        public IEnumerable<Group> GetAll()
        {
            return _songRepository.GetAll();
        }

        public Group Get(ObjectId id)
        {
            return _songRepository.GetById(id);
        }

        public void Create(Group group)
        {
            _songRepository.Create(group);
        }

        public bool Update(ObjectId id, Group group)
        {
            return _songRepository.Update(id, group);
        }

        public bool Delete(ObjectId id)
        {
            return _songRepository.Delete(id);
        }
    }
}
