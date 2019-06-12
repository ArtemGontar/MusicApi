using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Music.DataAccess.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.DataAccess.Entities
{
    public class Album : IEntity
    {
        public Album()
        {
            SongIds = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ObjectId ArtistId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string GroupId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> SongIds { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime ReleaseDate { get; set; }


    }
}
