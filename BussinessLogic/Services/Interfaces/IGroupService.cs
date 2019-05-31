using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using Music.DataAccess.Entities;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IGroupService : IService
    {
        IEnumerable<Group> GetAll();

        Group Get(ObjectId id);

        void Create(Group group);

        bool Update(ObjectId id, Group group);

        bool Delete(ObjectId id);
    }
}
