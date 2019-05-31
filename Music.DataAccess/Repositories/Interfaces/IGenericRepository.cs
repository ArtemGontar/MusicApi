using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Music.DataAccess.Entities.Interfaces;

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
        
        //Task<IQueryable<TEntity>> GetAllAsync();

        //Task<TEntity> GetByIdAsync(int id);

        //Task CreateAsync(TEntity entity);

        //Task UpdateAsync(int id, TEntity entity);

        //Task DeleteAsync(int id);
    }
}
