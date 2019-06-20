using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Music.DataAccess.Entities;

namespace Music.DataAccess
{
    public class AuthContext
    {

        public IMongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }

        public AuthContext(IOptions<Settings> settings)
        {
            MongoClient = new MongoClient(settings.Value.ConnectionString);
            if (MongoClient != null)
                MongoDatabase = MongoClient.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return MongoDatabase.GetCollection<User>("users");
            }
        }
    }
}
