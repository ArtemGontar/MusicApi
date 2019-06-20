using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Music.DataAccess.Entities;

namespace Music.DataAccess
{
    public class MusicDbContext : DbContext
    {

        public MusicDbContext(IOptions<Settings> settings)
        {
            MongoClient = new MongoClient(settings.Value.ConnectionString);
            if (MongoClient != null)
                MongoDatabase = MongoClient.GetDatabase(settings.Value.Database);
        }

        public IMongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
