using System;
using Music.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Music.DataAccess
{
    public class MusicDbContext : DbContext
    {

        public MusicDbContext()
        {
            MongoClient = new MongoClient("mongodb://localhost:27017");
            MongoDatabase = MongoClient.GetDatabase("TrackDB");
        }

        public IMongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Track> Tracks { get; set; }
    }
}
