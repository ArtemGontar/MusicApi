using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;

namespace Music.DataAccess.Entities
{
    public class Song : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ArtistId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AlbumId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }
    }
}
