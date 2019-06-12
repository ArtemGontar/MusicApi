using MongoDB.Bson;
using Music.DataAccess.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(ObjectId id);

        void Create(TEntity entity);

        bool Update(ObjectId id, TEntity entity);

        bool Delete(ObjectId id);
        
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(ObjectId id);

        Task CreateAsync(TEntity entity);

        Task<bool> UpdateAsync(ObjectId id, TEntity entity);

        Task<bool> DeleteAsync(ObjectId id);
    }
}
