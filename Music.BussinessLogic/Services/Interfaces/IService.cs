using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Music.DataAccess.Entities;
using Music.DataAccess.Entities.Interfaces;

namespace Music.BussinessLogic.Services.Interfaces
{
    public interface IService<T> where T : IEntity
    {
        IEnumerable<T> GetAll();

        T Get(ObjectId id);

        void Create(T entity);

        bool Update(ObjectId id, T entity);

        bool Delete(ObjectId id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(ObjectId id);

        Task CreateAsync(T entity);

        Task<bool> UpdateAsync(ObjectId id, T entity);

        Task<bool> DeleteAsync(ObjectId id);
    }
}
