using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class Song : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string ArtistId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AlbumId { get; set; }

        public long AmoutListening { get; set; }

        public long AmoutLikes { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }
    }
}
