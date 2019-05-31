using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Music.DataAccess.Entities;
using Music.DataAccess.Entities.Interfaces;
using Music.DataAccess.Repositories.Interfaces;

namespace Music.DataAccess.Repositories.Impementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly MusicDbContext _dbContext;
        private readonly IMongoCollection<TEntity> _collection;

        public GenericRepository(MusicDbContext dbContext, string collectionName)
        {
            _dbContext = dbContext;
            _collection = _dbContext.MongoDatabase.GetCollection<TEntity>(collectionName);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _collection.Find(entity => true).ToList();
        }

        public TEntity GetById(ObjectId id)
        {
            return _collection.Find(book => book.Id == id).FirstOrDefault();
        }

        public void Create(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public bool Update(ObjectId id, TEntity entity)
        {
            ReplaceOneResult updateResult =
                _collection
                    .ReplaceOne(
                        filter: g => g.Id == entity.Id,
                        replacement: entity);
            return updateResult.IsAcknowledged
                   && updateResult.ModifiedCount > 0;
        }

        public bool Delete(ObjectId id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = _collection
                .DeleteOne(filter);
            return deleteResult.IsAcknowledged
                   && deleteResult.DeletedCount > 0;
        }


        //public Task<IQueryable<TEntity>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<TEntity> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<TEntity>()
        //        .AsNoSonging()
        //        .FirstOrDefaultAsync(e => e.Id == id);
        //}

        //public async Task CreateAsync(TEntity entity)
        //{
        //    await _dbContext.Set<TEntity>().AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(int id, TEntity entity)
        //{
        //    _dbContext.Set<TEntity>().Update(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var entity = await GetByIdAsync(id);
        //    _dbContext.Set<TEntity>().Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

    }
}
